using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;

        public ProfileService(UserManager<AppUser> userManager,
            IAccountService accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<UserInfoViewModel> GetUserInfoAsync(string email)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            return new UserInfoViewModel
            {
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
            };
        }

        public async Task<UserInfoViewModel> GetUserForEditAsync(string userId)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            return new UserInfoViewModel
            {
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
            };
        }

        public async Task EditUserAsync(UserInfoViewModel model)
        {
            var appUser = await _userManager.FindByIdAsync(model.Id);
            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;
            appUser.Email = model.Email;
            appUser.UserName = model.Email;

            await _userManager.UpdateAsync(appUser);
            await _accountService.SignInAsync(appUser);
        }
    }
}
