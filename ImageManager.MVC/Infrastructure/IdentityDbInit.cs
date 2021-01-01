using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ImageManager.MVC.Infrastructure
{
    internal class IdentityDbInit
        : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
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

        protected override Task Seed(AppIdentityDbContext context)
        {
            await PerformInitialSetupAsync(context);
            base.Seed(context);
        }

        private static async Task PerformInitialSetupAsync(AppIdentityDbContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole { Name = UserRoles.Admin };
            var userRole = new IdentityRole { Name = UserRoles.User };

            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(userRole);

            await AddAdminAsync(userManager, adminRole, userRole);
            await AddUserAsync(userManager, userRole);
        }
    }
}
