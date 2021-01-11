using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
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
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(IImageRepository imageRepository,
            IUserRepository userRepository,
            ISubscriptionRepository subscriptionRepository,
            INotificationRepository notificationRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _subscriptionRepository = subscriptionRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task AddNotificationsForUserAsync(string userId, int imageId)
        {
            var subscriptionsId = await _subscriptionRepository.GetAll()
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

            foreach (var notification in notices)
            {
                await _notificationRepository.CreateAsync(notification);
            }
        }

        public async Task<IEnumerable<NotificationViewModel>> GetNotificationsAsync(string adminEmail)
        {
            var admin = await _userRepository.GetByEmailAsync(adminEmail);

            var notificationViewModels = from subscription in _subscriptionRepository.GetAll()
                                         join notice in _notificationRepository.GetAll() on subscription.Id equals notice.SubscriptionId
                                         join user in _userRepository.GetAll() on subscription.UserId equals user.Id
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
            var notice = await _notificationRepository.GetByIdAsync(notificationId);
            var imageViewModels = from img in _imageRepository.GetAll()
                                  join user in _userRepository.GetAll() on img.AppUserId equals user.Id
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
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            notification.HasRead = true;
            await _notificationRepository.UpdateAsync(notification);
        }
    }
}
