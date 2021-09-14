using Microsoft.AspNetCore.Mvc;

namespace Proj1_api.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("Error/{0}")]
        public IActionResult ErrorPage(int status)
        {
            return View();
        }
    }
}
