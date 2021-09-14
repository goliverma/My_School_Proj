using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace Proj1_api.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var modelMetadataProvider = context.HttpContext.RequestServices.GetService(typeof(IModelMetadataProvider)) as IModelMetadataProvider;
            var result = new ViewResult { ViewName = "_Error" };
            result.ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
