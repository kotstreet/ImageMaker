using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppIdentityDbContext _context;

        public SubscriptionService(AppIdentityDbContext context)
        {
            _context = context;
        }

        public Task<bool> HasSubscriptionAsync(string adminId, string userId)
        {
            return _context.Subscriptions
                .AnyAsync(subscription => subscription.AdminId == adminId && subscription.UserId == userId && subscription.IsActual == true);
        }

        public async Task AddSubscriptionAsync(string adminEmail, string userId)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);
            var oldSubscription = await _context.Subscriptions
                 .FirstOrDefaultAsync(subscription => subscription.AdminId == admin.Id && subscription.UserId == userId);

            if (oldSubscription == null)
            {
                var subscription = new Subscription
                {
                    AdminId = admin.Id,
                    UserId = userId,
                    IsActual = true,
                };
                _context.Subscriptions.Add(subscription);
            }
            else
            {
                oldSubscription.IsActual = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeactivateSubscriptionAsync(string adminEmail, string userId)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);
            var oldSubscription = await _context.Subscriptions
                 .FirstOrDefaultAsync(subscription => subscription.AdminId == admin.Id && subscription.UserId == userId);
            oldSubscription.IsActual = false;
            await _context.SaveChangesAsync();
        }
    }
}
