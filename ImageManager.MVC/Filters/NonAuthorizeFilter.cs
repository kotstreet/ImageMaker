using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ImageManager.MVC.Filters
{
    public class NonAuthorizeFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = null,
                    StatusCode = StatusCodes.Status403Forbidden,
                };
            }
        }
    }
}
