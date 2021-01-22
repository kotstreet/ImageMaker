using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppIdentityDbContext _context;

        public NotificationRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Notice> CreateAsync(Notice notice)
        {
            var createdNotice = _context.Notices.Add(notice);
            await _context.SaveChangesAsync();
            return createdNotice.Entity;
        }

        public async Task DeleteAsync(int noticeId)
        {
            var notice = await GetByIdAsync(noticeId);
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Notice> GetAll()
        {
            return _context.Notices.AsNoTracking();
        }

        public async Task<Notice> GetByIdAsync(int noticeId)
        {
            return await _context.Notices.FindAsync(noticeId);
        }

        public async Task<Notice> UpdateAsync(Notice notice)
        {
            var noticeFromDb = await GetByIdAsync(notice.Id);
            noticeFromDb.ImageId = notice.ImageId;
            noticeFromDb.SubscriptionId = notice.SubscriptionId;
            noticeFromDb.HasRead = notice.HasRead;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(notice.Id);
        }
    }
}
