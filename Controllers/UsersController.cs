using AspApiCours.Interfaces;
using AspApiCours.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspApiCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] ConnectionData data)
        {
            var user = userService.CheckUser(data);
            if (user != null)
            {
                var tokenString = userService.GenerateJWT(user);
                return Ok(new { token = tokenString });
            }
            return Unauthorized();
        }
    }
  
}
