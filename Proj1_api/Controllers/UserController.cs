using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Proj1_api.TokenAuthentication;

namespace Proj1_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ITokenManager tokenManager;

        public UserController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(User us)
        {
            if (tokenManager.Authenticate(us))
            {
                return Ok(new { Token = tokenManager.NewToken() });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "you are not authorized");
                return Unauthorized(ModelState);
            }
        }
    }
}
