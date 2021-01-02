using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ImageManager.MVC.Infrastructure
{
    internal static class IdentityDbInit
    {
        private const string AdminPassword = "admin1";
        private const string AdminEmail = "admin@mail.ru";
        private const string AdminFullName = "Anton Antonov";

        private const string UserPassword = "user11";
        private const string UserEmail = "user@mail.ru";
        private const string UserFullName = "Ivan Ivanov";

        private static async Task AddAdminAsync(UserManager<AppUser> userManager,
            IdentityRole adminRole,
            IdentityRole userRole)
        {
            if (await userManager.FindByEmailAsync(AdminEmail) != null)
            {
                return;
            }

            var admin = new AppUser
            {
                UserName = AdminEmail,
                Email = AdminEmail,
                FullName = AdminFullName,
            };
            var resultAdmin = await userManager.CreateAsync(admin, AdminPassword);
            if (resultAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, adminRole.Name);
                await userManager.AddToRoleAsync(admin, userRole.Name);
            }
        }

        private static async Task AddUserAsync(UserManager<AppUser> userManager, IdentityRole userRole)
        {
            if (await userManager.FindByEmailAsync(UserEmail) != null)
            {
                return;
            }

            var user = new AppUser
            {
                UserName = UserEmail,
                Email = UserEmail,
                FullName = UserFullName,
            };
            var resultUser = await userManager.CreateAsync(user, UserPassword);
            if (resultUser.Succeeded)
            {
                await userManager.AddToRoleAsync(user, userRole.Name);
            }
        }

        public static async Task SeedDataAsync(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var adminRole = new IdentityRole { Name = UserRoles.Admin };
            var userRole = new IdentityRole { Name = UserRoles.User };

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(adminRole);
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await roleManager.CreateAsync(userRole);
            }

            await AddAdminAsync(userManager, adminRole, userRole);
            await AddUserAsync(userManager, userRole);
        }
    }
}
