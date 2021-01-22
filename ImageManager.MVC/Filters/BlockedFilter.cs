using ImageManager.MVC.Constants;
using ImageManager.MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

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
                var userRepository = (IUserRepository)context.HttpContext.RequestServices.GetService(typeof(IUserRepository));

                var userEmail = context.HttpContext.User.Identity.Name;
                var user = userRepository.GetByEmailAsync(userEmail).Result;
                if (!user.IsActive || user == null)
                {
                    context.Result = new RedirectToActionResult(RedirectPath.LogoutAction, RedirectPath.AccountController, null);
                }
            }
        }
    }
}
