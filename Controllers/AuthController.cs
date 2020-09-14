using System.Threading.Tasks;
using _dotnetSandBox.Data;
using _dotnetSandBox.Dtos.user;
using _dotnetSandBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace _dotnetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new Models.User{username = request.username}, request.password
            );
            if(!response.success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Register(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(request.username, request.password);
            if(!response.success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}