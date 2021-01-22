using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Check if user with adminId subscribe on user with userId.
        /// </summary>
        /// <param name="adminId">The admin id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>True if subscribed, otherwise false.</returns>
        Task<bool> HasSubscriptionAsync(string adminId, string userId);

        /// <summary>
        /// Add a new subscription to database.
        /// </summary>
        /// <param name="adminEmail">The admin email.</param>
        /// <param name="userId">The user id.</param>
        Task AddSubscriptionAsync(string adminEmail, string userId);

        /// <summary>
        /// Deactivate a subscription in database.
        /// </summary>
        /// <param name="adminEmail">The admin email.</param>
        /// <param name="userId">The user id.</param>
        Task DeactivateSubscriptionAsync(string adminEmail, string userId);
    }
}
