using ImageManager.MVC.Constants;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ImageManager.MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;

        public ProfileController(ILogger<ProfileController> logger,
            IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Show()
        {
            _logger.LogInformation("Show action of ProfileController.");
            return View(await _profileService.GetUserInfoAsync(User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            _logger.LogInformation($"Edit get action of ProfileController with userId = {userId}.");
            return View(await _profileService.GetUserForEditAsync(userId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserInfoViewModel model)
        {
            _logger.LogInformation($"Edit post action of ProfileController with UserInfoViewModel = {JsonConvert.SerializeObject(model)}.");
            await _profileService.EditUserAsync(model);
            return RedirectToAction(RedirectPath.ShowAction , RedirectPath.ProfileController);
        }
    }
}
