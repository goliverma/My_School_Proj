using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NLog;

namespace Proj1.Models.Filter
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext context)
        {
            var cont = context.ActionDescriptor.DisplayName.ToString();
            var result = new ViewResult { ViewName = "_Error" };
            var modelMetadata = new EmptyModelMetadataProvider();
            result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
            result.ViewData.Add("HandleException", context.Exception.Message);
            result.ViewData.Add("InnerException", context.Exception.InnerException);
            logger.Error($"{cont} \n {context.Exception.Message} \n {context.Exception.InnerException}");
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
