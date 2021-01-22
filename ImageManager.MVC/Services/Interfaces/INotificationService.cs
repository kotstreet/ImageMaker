using ImageManager.MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Add notifications for all subscribers of the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="imageId">The image id.</param>
        Task AddNotificationsForUserAsync(string userId, int imageId);

        /// <summary>
        /// Get all notifications for a user.
        /// </summary>
        /// <param name="adminEmail">The user email.</param>
        /// <returns>List of NotificationViewModel.</returns>
        Task<IEnumerable<NotificationViewModel>> GetNotificationsAsync(string adminEmail);

        /// <summary>
        /// Get image path by id.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <returns>The image path with user info.</returns>
        Task<ImageViewModel> GetImagePathAsync(int notificationId);

        /// <summary>
        /// Mark the notification as read.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        Task MarkNotificationAsReadAsync(int notificationId);
    }
}
