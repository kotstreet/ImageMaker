using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public Task<AppUser> FindUserAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
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
            var user = await _userRepository.GetByEmailAsync(email);
            return user == null;
        }

        public Task<AppUser> CreateNewUserAsync(RegisterViewModel model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true,
            };
 
            return _userRepository.CreateAsync(user, model.Password);
        }

        public async Task AddUserToRoleAsync(AppUser user)
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }

        public async Task MarkUserAsAdminAsync(AppUser user)
        {
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        }

        public Task<bool> IsUserJustAUserAsync(AppUser user)
        {
            return _userManager.IsInRoleAsync(user, UserRoles.User);
        }

        public Task<bool> IsUserAdminAsync(AppUser user)
        {
            return _userManager.IsInRoleAsync(user, UserRoles.Admin);
        }

        public async Task RemoveFromRoleAsync(AppUser user, string role)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }
    }
}
