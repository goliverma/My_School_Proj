using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Proj1.Models.Filter;

namespace Proj1.Controllers
{
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    public class ErrorController : Controller
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        [Route("Error/{statusCode}")]
        public IActionResult ErrorPage(int statusCode)
        {
            var statuscoderesult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, The resource you request could not found";
                    ViewBag.Path = $"{statuscoderesult.OriginalPath.Trim('/')}/{statuscoderesult.OriginalQueryString}";
                    logger.Warn($"Sorry, The resource you request could not found \n " +
                        $"{statuscoderesult.OriginalPath.Trim('/')}/{statuscoderesult.OriginalQueryString}");
                    break;
            }
            return View();
        }
    }
}
