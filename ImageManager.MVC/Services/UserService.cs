using ImageManager.MVC.Constants;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Helpers;
using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleDataHelper _userRoleDataHelper;
        private readonly IAccountService _accountService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRoleDataHelper useRoleDataHelper,
            IUserRepository userRepository,
            IAccountService accountService,
            ISubscriptionService subscriptionService,
            ILogger<UserService> logger)
        {
            _userRoleDataHelper = useRoleDataHelper;
            _userRepository = userRepository;
            _accountService = accountService;
            _subscriptionService = subscriptionService;
            _logger = logger;
        }

        public async Task<List<UserWithRolesInfoViewModel>> GetAllUsersWithRolesAsync(string email)
        {
            var admin = await _userRepository.GetByEmailAsync(email);

            var users = _userRepository.GetAll();
            var userRoles = _userRoleDataHelper.GetAllUserRoles();
            var roles = _userRoleDataHelper.GetAllRoles();

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

            var usersForReturn = await usersWithRoleInfo
                .OrderByDescending(user => user.IsAdmin)
                .ThenBy(user => user.Email)
                .ToListAsync();

            for (var i = 0; i < usersForReturn.Count; i++)
            {
                usersForReturn.ElementAt(i).HasSubscription = await _subscriptionService.HasSubscriptionAsync(admin.Id, usersForReturn.ElementAt(i).Id);
            }

            _logger.LogInformation($"GetAllUsersWithRolesAsync method of UserService before return, usersForReturn= {JsonConvert.SerializeObject(usersForReturn)}.");
            return usersForReturn;
        }

        public async Task ActivateAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            user.IsActive = true;
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeactivateAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            user.IsActive = false;
            await _userRepository.UpdateAsync(user);
        }

        public async Task<EditUserViewModel> GetEditUserViewModel(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = await _accountService.IsUserAdminAsync(user),
                IsUser = await _accountService.IsUserJustAUserAsync(user),
            };

            return model;
        }

        public async Task<AppUser> CreateUserAsync(CreateUserViewModel model)
        {
            var registerViewModel = new RegisterViewModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
            };

            var user = await _accountService.CreateNewUserAsync(registerViewModel);
            if (user == null)
            {
                return null;
            }

            if (model.IsAdmin)
            {
                await _accountService.MarkUserAsAdminAsync(user);
            }
            if (model.IsUser)
            {
                await _accountService.AddUserToRoleAsync(user);
            }

            return user;
        }

        public async Task EditUserAsync(EditUserViewModel model)
        {
            var user = await _userRepository.GetByIdAsync(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;

            await _userRepository.UpdateAsync(user);

            if (model.IsAdmin != await _accountService.IsUserAdminAsync(user) && model.IsAdmin)
            {
                await _accountService.MarkUserAsAdminAsync(user);
            }
            else if (model.IsAdmin != await _accountService.IsUserAdminAsync(user) && !model.IsAdmin)
            {
                await _accountService.RemoveFromRoleAsync(user, UserRoles.Admin);
            }

            if (model.IsUser != await _accountService.IsUserJustAUserAsync(user) && model.IsUser)
            {
                await _accountService.AddUserToRoleAsync(user);
            }
            else if (model.IsUser != await _accountService.IsUserJustAUserAsync(user) && !model.IsUser)
            {
                await _accountService.RemoveFromRoleAsync(user, UserRoles.User);
            }
        }

        public async Task DeleteAsync(string userId)
        {
            await _userRepository.DeleteAsync(userId);
        }
    }
}
