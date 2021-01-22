using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace ImageManager.MVC.Repositories.Helpers
{
    public interface IUserRoleDataHelper
    {
        /// <summary>
        /// Get all user roles from database.
        /// </summary>
        /// <returns>All user roles.</returns>
        IQueryable<IdentityUserRole<string>> GetAllUserRoles();

        /// <summary>
        /// Get all roles from database.
        /// </summary>
        /// <returns>All roles.</returns>
        IQueryable<IdentityRole> GetAllRoles();
    }
}
