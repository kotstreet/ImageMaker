using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ImageManager.MVC.Infrastructure
{
    internal static class IdentityDbInit
    {
        private const string AdminPassword = "AdminPassword";
        private const string AdminEmail = "AdminEmail";
        private const string AdminFirstName = "AdminFirstName";
        private const string AdminLastName = "AdminLastName";

        private const string UserPassword = "UserPassword";
        private const string UserEmail = "UserEmail";
        private const string UserFirstName = "UserFirstName";
        private const string UserLastName = "UserLastName";

        private static async Task AddAdminAsync(UserManager<AppUser> userManager,
            IdentityRole adminRole,
            IdentityRole userRole,
            IConfiguration configuration)
        {
            var adminEmail = configuration.GetValue<string>(AdminEmail);
            if (await userManager.FindByEmailAsync(adminEmail) != null)
            {
                return;
            }

            var admin = new AppUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = configuration.GetValue<string>(AdminFirstName),
                LastName = configuration.GetValue<string>(AdminLastName),
                IsActive = true,
            };

            var adminPassword = configuration.GetValue<string>(AdminPassword);
            var resultAdmin = await userManager.CreateAsync(admin, adminPassword);
            if (resultAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, adminRole.Name);
                await userManager.AddToRoleAsync(admin, userRole.Name);
            }
        }

        private static async Task AddUserAsync(UserManager<AppUser> userManager,
            IdentityRole userRole,
            IConfiguration configuration)
        {
            var userEmail = configuration.GetValue<string>(UserEmail);
            if (await userManager.FindByEmailAsync(userEmail) != null)
            {
                return;
            }

            var user = new AppUser
            {
                UserName = userEmail,
                Email = userEmail,
                FirstName = configuration.GetValue<string>(UserFirstName),
                LastName = configuration.GetValue<string>(UserLastName),
                IsActive = true,
            };

            var userPassword = configuration.GetValue<string>(UserPassword);
            var resultUser = await userManager.CreateAsync(user, userPassword);
            if (resultUser.Succeeded)
            {
                await userManager.AddToRoleAsync(user, userRole.Name);
            }
        }

        public static async Task SeedDataAsync(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
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

            await AddAdminAsync(userManager, adminRole, userRole, configuration);
            await AddUserAsync(userManager, userRole, configuration);
        }
    }
}
