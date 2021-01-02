using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public Task<AppUser> FindUserAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        public async Task SignInAsync(AppUser user)
        {
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }

        public async Task<AppUser> CreateNewUserAsync(RegisterViewModel model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded ? user : null;
        }

        public async Task AddUserToRoleAsync(AppUser user)
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }
    }
}
