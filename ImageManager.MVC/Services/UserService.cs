using ImageManager.MVC.Constants;
using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly AppIdentityDbContext _context;

        public UserService(AppIdentityDbContext context)
        {
            _context = context;
        }

        public Task<List<UserWithRolesInfoViewModel>> GetAllUsersWithRolesAsync()
        {
            var users = _context.Users.AsQueryable();
            var userRoles = _context.UserRoles.AsQueryable();
            var roles = _context.Roles.AsQueryable();

            var usersWithRoleInfo = users.Select(user => new UserWithRolesInfoViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                IsActive = user.IsActive,
                IsAdmin = roles
                  .Where(role => role.Name == UserRoles.Admin)
                  .Where(role => userRoles
                     .Where(userRole => userRole.UserId == user.Id)
                     .Select(userRole => userRole.RoleId)
                     .Contains(role.Id))
                  .Any(),
                IsUser = roles
                  .Where(role => role.Name == UserRoles.User)
                  .Where(role => userRoles
                     .Where(userRole => userRole.UserId == user.Id)
                     .Select(userRole => userRole.RoleId)
                     .Contains(role.Id))
                  .Any(),
            });

            return usersWithRoleInfo.ToListAsync();
            //return await (from user in users
            //              join userRole in userRoles on user.Id equals userRole.UserId
            //              join role in roles on userRole.RoleId equals role.Id
            //              select new UserWithRolesInfoViewModel
            //              {
            //                  Id = user.Id,
            //                  Email = user.Email,
            //                  FullName = user.FullName,
            //                  IsActive = user.IsActive,
            //                  IsAdmin = role.Name == UserRoles.Admin,
            //                  IsUser = role.Name == UserRoles.User,
            //              })
            //        .ToListAsync();
        }
    }
}
