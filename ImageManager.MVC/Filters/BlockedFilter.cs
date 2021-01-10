using ImageManager.MVC.Constants;
using ImageManager.MVC.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ImageManager.MVC.Filters
{
    public class BlockedFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // no realization
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var dbContext = (AppIdentityDbContext)context.HttpContext.RequestServices.GetService(typeof(AppIdentityDbContext));

                var userEmail = context.HttpContext.User.Identity.Name;
                var user = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                if (!user.IsActive || user == null)
                {
                    context.Result = new RedirectToActionResult(RedirectPath.LogoutAction, RedirectPath.AccountController, null);
                }
            }
        }
    }
}
