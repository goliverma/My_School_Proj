using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proj1_api.TokenAuthentication;
using System;
using System.Linq;

namespace Proj1_api.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = context.HttpContext.RequestServices.GetService(typeof(ITokenManager)) as ITokenManager;
            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;
            var token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            if (!result)
            {
                context.ModelState.AddModelError("Unauthorized", "You are not authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
