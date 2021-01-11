using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppIdentityDbContext _context;

        public NotificationService(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task AddNotificationsForUserAsync(string userId, int imageId)
        {
            var subscriptionsId = await _context.Subscriptions
                .Where(subscription => subscription.UserId == userId && subscription.IsActual)
                .Select(subscription => subscription.Id)
                .ToListAsync();

            var notices = new List<Notice>();
            subscriptionsId.ForEach(subscriptionId => notices.Add(new Notice
            {
                ImageId = imageId,
                SubscriptionId = subscriptionId,
                HasRead = false,
            }));

            _context.Notices.AddRange(notices);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotificationViewModel>> GetNotificationsAsync(string adminEmail)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);

            var notificationViewModels = from subscription in _context.Subscriptions
                                         join notice in _context.Notices on subscription.Id equals notice.SubscriptionId
                                         join user in _context.Users on subscription.UserId equals user.Id
                                         where subscription.AdminId == admin.Id
                                         orderby notice.Id descending
                                         select new NotificationViewModel
                                         {
                                             NotificationId = notice.Id,
                                             Email = user.Email,
                                             FullName = user.FullName,
                                             HasRead = notice.HasRead,
                                         };
            return notificationViewModels;
        }

        public async Task<ImageViewModel> GetImagePathAsync(int notificationId)
        {
            var notice = await _context.Notices.FindAsync(notificationId);
            var imageViewModels = from img in _context.Images
                                  join user in _context.Users on img.AppUserId equals user.Id
                                  where img.Id == notice.ImageId
                                  select new ImageViewModel
                                  {
                                      Path = img.Path,
                                      FullName = user.FullName,
                                      Email = user.Email,
                                  };


            return await imageViewModels.FirstAsync();
        }

        public async Task MarkNotificationAsReadAsync(int notificationId)
        {
            var notice = await _context.Notices.FindAsync(notificationId);
            notice.HasRead = true;
            await _context.SaveChangesAsync();
        }
    }
}
