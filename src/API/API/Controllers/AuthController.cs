using Application.Identity;
using Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
        [HttpPost("register-admin")]
        public async Task<ActionResult<RegisterResponse>> RegisterAdmin(RegisterRequest request)
        {
            return Ok(await _authenticationService.RegisterAdmin(request));
        }

        [HttpPost("logout")]
        public async Task<string> Logout()
        {
            return await _authenticationService.Logout();
        }
    }
}
