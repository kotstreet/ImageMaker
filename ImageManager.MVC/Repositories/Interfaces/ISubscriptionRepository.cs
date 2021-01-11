using ImageManager.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        /// <summary>
        /// Get subscription by id.
        /// </summary>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <returns>Subscription.</returns>
        Task<Subscription> GetByIdAsync(int subscriptionId);


        /// <summary>
        /// Get all subscriptions from database.
        /// </summary>
        /// <returns>All subscriptions.</returns>
        IQueryable<Subscription> GetAll();

        /// <summary>
        /// Delete subscription by id.
        /// </summary>
        /// <param name="subscriptionId">The subscription id.</param>
        Task DeleteAsync(int subscriptionId);

        /// <summary>
        /// Create new subscription.
        /// </summary>
        /// <param name="notice">The subscription for create.</param>
        /// <returns>Created subscription.</returns>
        Task<Subscription> CreateAsync(Subscription subscription);

        /// <summary>
        /// Update subscription.
        /// </summary>
        /// <param name="subscription">The subscription for update.</param>
        /// <returns>Updated subscription.</returns>
        Task<Subscription> UpdateAsync(Subscription subscription);
    }
}
