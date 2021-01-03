using ImageManager.MVC.Constants;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ImageManager.MVC.Controllers
{
    [Authorize(UserRoles.Admin)]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            _logger.LogInformation("ShowAll action of UserController.");
            return View(await _userService.GetAllUsersWithRolesAsync());
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
    }
}
