using ImageManager.MVC.Constants;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ImageManager.MVC.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationService _notificationService;

        public NotificationController(ILogger<NotificationController> logger,
            INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll action.");
            return View(await _notificationService.GetNotificationsAsync(User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> ShowImage(int notificationId)
        {
            _logger.LogInformation($"ShowImage action with notificationId = {notificationId}.");
            await _notificationService.MarkNotificationAsReadAsync(notificationId);
            return View(await _notificationService.GetImagePathAsync(notificationId));
        }
    }
}
