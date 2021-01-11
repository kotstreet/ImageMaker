using ImageManager.MVC.Models;
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

        /// <summary>
        /// Get model for edit the user info and roles.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Model for Edit the user.</returns>
        Task<EditUserViewModel> GetEditUserViewModel(string userId);

        /// <summary>
        /// Create a new user with selected roles.
        /// </summary>
        /// <param name="model">Model for create a new user.</param>
        /// <returns>Created user if all is OK, otherwise null.</returns>
        Task<AppUser> CreateUserAsync(CreateUserViewModel model);

        /// <summary>
        /// Edit a user info and roles.
        /// </summary>
        /// <param name="model">Model for edit the user.</param>
        Task EditUserAsync(EditUserViewModel model);

        /// <summary>
        /// Delete user from database.
        /// </summary>
        /// <param name="userId">The user id.</param>
        Task DeleteAsync(string userId);
    }
}
