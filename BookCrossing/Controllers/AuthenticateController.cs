using System.IdentityModel.Tokens.Jwt;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Security.Claims;
using BookCrossing.Application.Interfaces;
using BookCrossing.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookCrossing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticateController(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.Login(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authenticationService.Register(request);

            return Ok(response);
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(RegisterRequest request)
        //{
        //    var user = new User { Email = request.Email, UserName = request.UserName };
        //    var result = await _userManager.CreateAsync(user, request.Password);
        //    if (result.Succeeded)
        //    {
        //        await _signInManager.SignInAsync(user, false);
        //    }

        //    return Ok();
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginRequest userForLogin)
        //{
        //    var result =
        //        await _signInManager.PasswordSignInAsync(userForLogin.Username, userForLogin.Password, false, false);
        //    if (result.Succeeded)
        //    {
        //        var user = await _userManager.FindByNameAsync(userForLogin.Username);
        //        var claims = new List<Claim>
        //        {
        //            new Claim("name", user.UserName),
        //            new Claim("email", user.Email),
        //            new Claim("id", user.Id)
        //        };
        //        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        var now = DateTime.UtcNow;
        //        var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.ISSUER,
        //            audience: AuthOptions.AUDIENCE,
        //            notBefore: now,
        //            claims: claimsIdentity.Claims,
        //            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
        //                SecurityAlgorithms.HmacSha256));
        //        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        //        //return Ok(encodedJwt);
        //        return Ok(new Models.Token(encodedJwt));
        //    }

        //    return BadRequest();
        //}
    }
}
