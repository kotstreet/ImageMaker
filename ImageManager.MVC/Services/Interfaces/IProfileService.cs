using ImageManager.MVC.ViewModels;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface IProfileService
    {
        /// <summary>
        /// Get info of the user for show.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <returns>UserInfoViewModel.</returns>
        Task<UserInfoViewModel> GetUserInfoAsync(string email);

        /// <summary>
        /// Get info of the user for edit one.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>UserInfoViewModel.</returns>
        Task<UserInfoViewModel> GetUserForEditAsync(string userId);

        /// <summary>
        /// Update info aboute a user.
        /// </summary>
        /// <param name="model">Model with information for update the user.</param>
        Task EditUserAsync(UserInfoViewModel model);
    }
}
