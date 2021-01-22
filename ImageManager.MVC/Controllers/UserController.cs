using ImageManager.MVC.Constants;
using ImageManager.MVC.Filters;
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
    [BlockedFilter]
    [Authorize(Roles = UserRoles.Admin)]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IImageService _imageService;

        public UserController(ILogger<UserController> logger,
            IStringLocalizer<UserController> localizer,
            IUserService userService,
            ISubscriptionService subscriptionService,
            IAccountService accountService,
            IImageService imageService)
        {
            _logger = logger;
            _localizer = localizer;
            _userService = userService;
            _accountService = accountService;
            _subscriptionService = subscriptionService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            _logger.LogInformation("ShowAll action of UserController.");
            return View(await _userService.GetAllUsersWithRolesAsync(User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> ShowImage(string userId)
        {
            _logger.LogInformation($"ShowImage action of UserController with userId = {userId}.");
            return View(await _imageService.GetImagesByUserIdAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> Activate(string userId)
        {
            _logger.LogInformation("Activate action of UserController.");
            await _userService.ActivateAsync(userId);
            return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
        }

        [HttpGet]
        public async Task<IActionResult> Deactivate(string userId)
        {
            _logger.LogInformation("Deactivate action of UserController.");
            await _userService.DeactivateAsync(userId);
            return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Create get action of UserController.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            _logger.LogInformation($"Create post action of UserController with model = {JsonConvert.SerializeObject(model)}.");
            if (!ModelState.IsValid || model == null)
            {
                _logger.LogDebug("Create action, model is not valid.");
                return View(model);
            }

            if (model.IsAdmin == false && model.IsUser == false)
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.RoleNotSelected]);
                _logger.LogDebug("Create action, no one roles selected.");
                return View(model);
            }

            if (!await _accountService.IsEmailUniqueAsync(model.Email))
            {
                ModelState.AddModelError(ModelErrorMessages.EmailField, _localizer[ModelErrorMessages.EmailIsNotUnique]);
                _logger.LogDebug("Create action, email is not unique.");
                return View(model);
            }

            var user = await _userService.CreateUserAsync(model);
            if (user != null)
            {
                _logger.LogDebug("Create action, user created.");
                return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
            }
            else
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.SomethingIsGoingWrong]);
                _logger.LogDebug("Create action, something was wrong while create user.");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            _logger.LogInformation($"Edit get action of UserController with userId = {userId}.");
            return View(await _userService.GetEditUserViewModel(userId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            _logger.LogInformation($"Edit post action of UserController with model = {JsonConvert.SerializeObject(model)}.");
            if (!ModelState.IsValid || model == null)
            {
                _logger.LogDebug("Edit action, model is not valid.");
                return View(model);
            }

            if (model.IsAdmin == false && model.IsUser == false)
            {
                ModelState.AddModelError(string.Empty, _localizer[ModelErrorMessages.RoleNotSelected]);
                _logger.LogDebug("Edit action, no one roles selected.");
                return View(model);
            }

            var modelBefore = await _userService.GetEditUserViewModel(model.Id);
            if (modelBefore.Email != model.Email && await _accountService.IsEmailUniqueAsync(model.Email) == false)
            {
                ModelState.AddModelError(ModelErrorMessages.EmailField, _localizer[ModelErrorMessages.EmailIsNotUnique]);
                _logger.LogDebug("Edit action, email is not unique.");
                return View(model);
            }
            else
            {
                await _userService.EditUserAsync(model);
                _logger.LogDebug("Edit action, user edited.");
                return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string userId)
        {
            _logger.LogInformation($"Delete action of UserController with userId = {userId}.");
            await _userService.DeleteAsync(userId);
            return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribe(string userId)
        {
            _logger.LogInformation($"Subscribe action of UserController with userId = {userId}.");
            await _subscriptionService.AddSubscriptionAsync(User.Identity.Name, userId);
            return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
        }

        [HttpGet]
        public async Task<IActionResult> Unsubscribe(string userId)
        {
            _logger.LogInformation($"Unsubscribe action of UserController with userId = {userId}.");
            await _subscriptionService.DeactivateSubscriptionAsync(User.Identity.Name, userId);
            return RedirectToAction(RedirectPath.ShowAllAction, RedirectPath.UserController);
        }
    }
}
