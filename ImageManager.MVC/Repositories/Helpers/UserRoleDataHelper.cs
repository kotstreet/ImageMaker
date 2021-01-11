using ImageManager.MVC.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace ImageManager.MVC.Repositories.Helpers
{
    public class UserRoleDataHelper : IUserRoleDataHelper
    {
        private readonly AppIdentityDbContext _context;

        public UserRoleDataHelper(AppIdentityDbContext context)
        {
            _context = context;
        }

        public IQueryable<IdentityRole> GetAllRoles()
        {
            return _context.Roles.AsQueryable();
        }

        public IQueryable<IdentityUserRole<string>> GetAllUserRoles()
        {
            return _context.UserRoles.AsQueryable();
        }
    }
}
