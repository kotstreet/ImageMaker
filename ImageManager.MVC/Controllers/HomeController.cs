using ImageManager.MVC.Constants;
using ImageManager.MVC.Filters;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ImageManager.MVC.Controllers
{
    [BlockedFilter]
    [Authorize(Roles = UserRoles.User)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageService _imageService;

        public HomeController(ILogger<HomeController> logger,
            IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogDebug("Index method of HomeController.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(string imageUrl)
        {
            _logger.LogInformation($"AddImage method of HomeController with imageUrl = {imageUrl}");
            if (string.IsNullOrEmpty(imageUrl))
            {
                _logger.LogDebug("AddImage method of HomeController, bad imageUrl.");
                return Json(new { success = true, msg = HttpMessages.ImageIsEmptyError });
            }
            else
            {
                await _imageService.AddImageToUserAsync(User.Identity.Name, imageUrl);
                _logger.LogDebug("AddImage method of HomeController, all is OK.");
                return Json(new { success = true, msg = HttpMessages.SuccessfulOperation });
            }
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            var model = await _imageService.GetImagesByEmailAsync(User.Identity.Name);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
