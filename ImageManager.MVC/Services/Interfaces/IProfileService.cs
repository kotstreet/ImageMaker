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
    }
}
