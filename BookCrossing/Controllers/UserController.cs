using BookCrossing.Application.ViewModels.UserViewModels;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly UserManager<User> _userManager;


        public UserController(IUserContext userContext, UserManager<User> userManager)
        {
            _userContext = userContext;
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<UserViewModel> GetUser()
        {
            var userId =  _userContext.UserId.ToString();

            var user = await _userManager.FindByIdAsync(userId);

            var userVm = new UserViewModel()
            {
                Name = user.UserName,
                Email = user.Email
            };

            return userVm;
        }

        [HttpPost("editUser")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var userId = _userContext.UserId.ToString();

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.UserName = model.Name;
                user.Email = model.Email;

                await _userManager.UpdateAsync(user);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = _userContext.UserId.ToString();

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
