using ImageManager.MVC.Models;
using ImageManager.MVC.ViewModels;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Find user by email.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <returns>The user.</returns>
        Task<AppUser> FindUserAsync(string email);

        /// <summary>
        /// Check if the password valid for the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if the password is valid, otherwise false.</returns>
        Task<bool> CheckPasswordAsync(AppUser user, string password);

        /// <summary>
        /// Sign user in.
        /// </summary>
        /// <param name="user">The user.</param>
        Task SignInAsync(AppUser user);

        /// <summary>
        /// Log out any user.
        /// </summary>
        Task LogOutAsync();

        /// <summary>
        /// Check if the email unique in database.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>True if email is unique, otherwise false.</returns>
        Task<bool> IsEmailUniqueAsync(string email);

        /// <summary>
        /// Create new user and add one in database.
        /// </summary>
        /// <param name="model">Register model for registration new user.</param>
        /// <returns>Created user if all is OK, otherwise null.</returns>
        Task<AppUser> CreateNewUserAsync(RegisterViewModel model);

        /// <summary>
        /// Add User role to a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        Task AddUserToRoleAsync(AppUser user);
    }
}
