using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAccountService _accountService;

        public ProfileService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<UserInfoViewModel> GetUserInfoAsync(string email)
        {
            var appUser = await _accountService.FindUserAsync(email);
            return new UserInfoViewModel
            {
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                IsActive = appUser.IsActive,
            };
        }
    }
}
