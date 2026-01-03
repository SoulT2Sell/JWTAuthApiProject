using JWTProject.Dtos;
using JWTProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JWTProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthServices services) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
        {
            var response = await services.RegisterAsync(request);
            return response == null ? BadRequest("Username Already Exists!") : Ok(response);    
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            var response = await services.LoginAsync(request);
            return response == null ? BadRequest("Username Or Password Is Incorrect!") : Ok(response);
        }

        [Authorize]
        [HttpGet("Authorized")]
        public ActionResult<string> Authorized()
        {
            return Ok("your accessing Authorized Section");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AdminAuthorized")]
        public ActionResult<string> AdminAuthorized()
        {
            return Ok("your accessing Admin Section");
        }


    }
}
