using ImageManager.MVC.Constants;
using ImageManager.MVC.Filters;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ImageManager.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IStringLocalizer<AccountController> _localizer;

        public AccountController(ILogger<AccountController> logger,
            IAccountService accountService,
            IStringLocalizer<AccountController> localizer)
        {
            _logger = logger;
            _accountService = accountService;
            _localizer = localizer;
        }

        private async Task<IActionResult> SettingActionForReturnAferLoginAsync(AppUser user)
        {
            if (await _accountService.IsUserJustAUserAsync(user))
            {
                _logger.LogDebug("Login action, user signed in as User.");
                return RedirectToAction(RedirectPath.IndexAction, RedirectPath.HomeController);
            }
            else if (await _accountService.IsUserAdminAsync(user))
            {
                _logger.LogDebug("Login action, user signed in as Admin.");
                return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
            }
            else
            {
                _logger.LogDebug("Login action, user signed in, but have not any role.");
                return BadRequest(_localizer[ModelErrorMessages.YouHaveNotAnyRole]);
            }
        }

        [NonAuthorizeFilter]
        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login get action.");
            return View();
        }

        [NonAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation($"Login action of AccountController with LoginViewModel = {JsonConvert.SerializeObject(model)}.");
            if (!ModelState.IsValid || model == null)
            {
                _logger.LogDebug("Login action, model is not valid.");
                return View(model);
            }

            var user = await _accountService.FindUserAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.UserNotExist]); 
                _logger.LogDebug("Login action, user with such email is not exist yet.");
                return View(model);
            }

            if (!await _accountService.CheckPasswordAsync(user, model.Password))
            {
                ModelState.AddModelError(string.Empty, _localizer[ ModelErrorMessages.PasswordOrEmailIncorrect]); 
                _logger.LogDebug("Login action, password is not valid for the email.");
                return View(model);
            }
            else if (!user.IsActive)
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.UserIsNotActive]); 
                _logger.LogDebug("Login action, user is not activated.");
                return View(model);
            }
            else
            {
                await _accountService.SignInAsync(user);
                return await SettingActionForReturnAferLoginAsync(user);
            }
        }

        [NonAuthorizeFilter]
        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Register get action.");
            return View();
        }

        [NonAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            _logger.LogInformation($"Register action of AccountController with RegisterViewModel = {JsonConvert.SerializeObject(model)}.");
            if (!ModelState.IsValid || model == null)
            {
                _logger.LogDebug("Register action, model is not valid.");
                return View(model);
            }

            if (!await _accountService.IsEmailUniqueAsync(model.Email))
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.EmailIsNotUnique]);
                _logger.LogDebug("Register action, email is not unique.");
                return View(model);
            }

            var user = await _accountService.CreateNewUserAsync(model);
            if (user != null)
            {
                await _accountService.AddUserToRoleAsync(user);
                await _accountService.SignInAsync(user);

                _logger.LogDebug("Register action, user created and authorized.");
                return RedirectToAction(RedirectPath.IndexAction, RedirectPath.HomeController);
            }
            else
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.SomethingIsGoingWrong]);
                _logger.LogDebug("Register action, something was wrong while create user.");
                return View(model);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _accountService.LogOutAsync();
            _logger.LogInformation("Logout action, user loged out.");
            return RedirectToAction(RedirectPath.IndexAction, RedirectPath.HomeController);
        }
    }
}
