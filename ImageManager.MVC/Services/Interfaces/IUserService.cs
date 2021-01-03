using ImageManager.MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get all users with their base info and info aboute their roles.
        /// </summary>
        /// <returns>UserWithRolesInfoViewModel.</returns>
        Task<List<UserWithRolesInfoViewModel>> GetAllUsersWithRolesAsync();

        /// <summary>
        /// Activate user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        Task ActivateAsync(string userId);

        /// <summary>
        /// Deactivate user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        Task DeactivateAsync(string userId);
    }
}
