using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;

        public ProfileService(IUserRepository userRepository,
            IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        public async Task<UserInfoViewModel> GetUserInfoAsync(string email)
        {
            var appUser = await _userRepository.GetByEmailAsync(email);
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
            var appUser = await _userRepository.GetByIdAsync(userId);
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
            var appUser = await _userRepository.GetByIdAsync(model.Id);

            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;
            appUser.Email = model.Email;
            appUser.UserName = model.Email;
            await _userRepository.UpdateAsync(appUser);

            await _accountService.SignInAsync(appUser);
        }
    }
}
