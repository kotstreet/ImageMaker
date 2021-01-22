using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(IUserRepository userRepository,
            ISubscriptionRepository subscriptionRepository)
        {
            _userRepository = userRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<bool> HasSubscriptionAsync(string adminId, string userId)
        {
            return _subscriptionRepository.GetAll()
                .AnyAsync(subscription => subscription.AdminId == adminId && subscription.UserId == userId && subscription.IsActual == true);
        }

        public async Task AddSubscriptionAsync(string adminEmail, string userId)
        {
            var admin = await _userRepository.GetByEmailAsync(adminEmail);
            var oldSubscription = await _subscriptionRepository.GetAll()
                 .FirstOrDefaultAsync(subscription => subscription.AdminId == admin.Id && subscription.UserId == userId);

            if (oldSubscription == null)
            {
                var subscription = new Subscription
                {
                    AdminId = admin.Id,
                    UserId = userId,
                    IsActual = true,
                };
                await _subscriptionRepository.CreateAsync(subscription);
            }
            else
            {
                oldSubscription.IsActual = true;
                await _subscriptionRepository.UpdateAsync(oldSubscription);
            }

        }

        public async Task DeactivateSubscriptionAsync(string adminEmail, string userId)
        {
            var admin = await _userRepository.GetByEmailAsync(adminEmail);
            var oldSubscription = await _subscriptionRepository.GetAll()
                 .FirstOrDefaultAsync(subscription => subscription.AdminId == admin.Id && subscription.UserId == userId);
            oldSubscription.IsActual = false;
            await _subscriptionRepository.UpdateAsync(oldSubscription);
        }
    }
}
