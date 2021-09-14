using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Proj1.Models.Filter;
using Proj1.TokenAuthentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proj1.Controllers
{
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    public class UserController : Controller
    {
        private readonly IUserRepo ucontext;
        private readonly ITokenManager tokenManager;

        public UserController(IUserRepo ucontext, ITokenManager tokenManager)
        {
            this.ucontext = ucontext;
            this.tokenManager = tokenManager;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> LoginAsync(User u, string returnUrl)
        {
            var ua = ucontext.Login(u);
            if (ua != null && ua.IsActive)
            {
                HttpContext.Session.SetString("userLoginName", ua.UserName);
                var token = tokenManager.NewToken();
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ua.UserName),
                    new Claim(ClaimTypes.Role, ua.UserRoles),
                    new Claim("Authorization", token.Value)
                };
                var identity = new ClaimsIdentity(claim, "MyAuthCooki");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyAuthCooki", claimsPrincipal);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    var url = returnUrl.Split('/');
                    return RedirectToAction(url[2], url[1]);
                }
                else
                {
                    return RedirectToAction("Index", "School");
                }
            }
            else
            {
                ViewBag.error = "User Name or password is invalid";
            }
            return View();
        }
        public async Task<IActionResult> LogoutAsync()
        {
            if (HttpContext.Session.GetString("userLoginName") != null)
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync("MyAuthCooki");
            }
            return RedirectToAction("Login", "User");
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            ViewData["returnUserName"] = HttpContext.User.Identity.Name.ToString();
            return View();
        }
    }
}
