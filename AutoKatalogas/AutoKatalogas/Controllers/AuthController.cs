using Microsoft.AspNetCore.Mvc;
using AutoKatalogas.Auth.Model;
using Microsoft.AspNetCore.Identity;
using AutoKatalogas.Auth;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace AutoKatalogas.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ForumRestUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<ForumRestUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route(template:"register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if(user != null)
            {
                return BadRequest(error: "Request invalid");
            }

            var newUser = new ForumRestUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            await _userManager.AddToRoleAsync(newUser, ForumRoles.ForumUser);
            if (!createUserResult.Succeeded)
            {
                return BadRequest(error: "Create user error");
            }
            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));
        }

        [HttpPost]
        [Route(template: "login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return BadRequest(error: "Invalid user name or pasword.");
            }

            var isPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isPassword)
            {
                return BadRequest(error: "Invalid user name or pasword.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

            return Ok(new SuccessfulLoginDto(accessToken));
        }
    }
}
