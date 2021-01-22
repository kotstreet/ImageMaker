using ImageManager.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>User.</returns>
        Task<AppUser> GetByIdAsync(string userId);

        /// <summary>
        /// Get user by Email.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <returns>User.</returns>
        Task<AppUser> GetByEmailAsync(string email);

        /// <summary>
        /// Get all users from database.
        /// </summary>
        /// <returns>All users.</returns>
        IQueryable<AppUser> GetAll();

        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        Task DeleteAsync(string userId);

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="appUser">The user for create.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Created user.</returns>
        Task<AppUser> CreateAsync(AppUser appUser, string password);

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="appUser">The user for update.</param>
        /// <returns>Updated user.</returns>
        Task<AppUser> UpdateAsync(AppUser appUser);
    }
}
