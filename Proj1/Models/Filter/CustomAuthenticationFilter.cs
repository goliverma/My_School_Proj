using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NLog;
using Proj1.TokenAuthentication;
using System;
using System.Linq;

namespace Proj1.Models.Filter
{
    public class CustomAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = context.HttpContext.RequestServices.GetService(typeof(ITokenManager)) as ITokenManager;

            var result = true;
            if (!context.HttpContext.User.Claims.Any(x => x.Type == "Authorization"))
                result = false;
            string token = string.Empty;
            if(result)
            {
                token = context.HttpContext.User.Claims.First(x => x.Type == "Authorization").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            if(!result)
            {
                var result1 = new ViewResult { ViewName = "_Error" };
                var modelMetadata = new EmptyModelMetadataProvider();
                result1.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
                result1.ViewData.Add("HandleException", "Authentication token is expire Plz login again");
                logger.Warn($"{context.ModelState}");
                context.Result = result1;
            }
        }
    }
}
