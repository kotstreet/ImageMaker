using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppIdentityDbContext _context;

        public SubscriptionRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> CreateAsync(Subscription subscription)
        {
            var createdSubscription = _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return createdSubscription.Entity;
        }

        public async Task DeleteAsync(int subscriptionId)
        {
            var subscription = await GetByIdAsync(subscriptionId);
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Subscription> GetAll()
        {
            return _context.Subscriptions.AsNoTracking();
        }

        public async Task<Subscription> GetByIdAsync(int subscriptionId)
        {
            return await _context.Subscriptions.FindAsync(subscriptionId);
        }

        public async Task<Subscription> UpdateAsync(Subscription subscription)
        {
            var subscriptionFromDb = await GetByIdAsync(subscription.Id);
            subscriptionFromDb.AdminId = subscription.AdminId;
            subscriptionFromDb.UserId = subscription.UserId;
            subscriptionFromDb.IsActual = subscription.IsActual;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(subscription.Id);
        }
    }
}
