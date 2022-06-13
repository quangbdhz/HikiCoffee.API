using HikiCoffee.Application.MailConfirms;
using HikiCoffee.Application.Users;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.MailConfirms;
using HikiCoffee.ViewModels.Users;
using HikiCoffee.ViewModels.Users.RoleDataRequest;
using HikiCoffee.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailConfirmService _emailConfirmService;

        public UsersController(IUserService userService, IMailConfirmService emailConfirmService)
        {
            _userService = userService;
            _emailConfirmService = emailConfirmService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Login(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            if (string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(result);
            }

            RefreshTokenViewModel refreshTokenViewModel = _userService.GenerateRefreshTokenViewModel();

            var refreshToken = await SetRefreshToken(refreshTokenViewModel, result.ResultObj);

            if (refreshToken == "false")
                return BadRequest("Error Set Refresh Token");

            return Ok(result);
        }

        [HttpPost("ConfirmMail")]
        [AllowAnonymous]
        public async Task<ApiResult<bool>> ConfirmMail(string userName)
        {
            var result = await _userService.ConfirmMail(userName);
            return result;
        }

        [HttpPost("RefreshToken/{userId}")]
        public async Task<IActionResult> RefreshToken(Guid userId)
        {
            var refreshToken = Request.Cookies["refreshToken"];


            var newToken = await _userService.RefreshToken(userId, refreshToken);

            if (!newToken.IsSuccessed)
                return BadRequest(newToken.Message);


            RefreshTokenViewModel refreshTokenViewModel = _userService.GenerateRefreshTokenViewModel();

            var result = await SetRefreshToken(refreshTokenViewModel, userId);

            if (result == "false")
                return BadRequest("Error Set Refresh Token");

            return Ok(newToken);
        }

        [NonAction]
        private async Task<string> SetRefreshToken(RefreshTokenViewModel newRefreshTokenViewModel, Guid userId)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshTokenViewModel.Expires
            };

            Response.Cookies.Append("refreshToken", newRefreshTokenViewModel.Token, cookieOptions);

            var result = await _userService.SetRefreshToken(userId, newRefreshTokenViewModel);

            if (result.IsSuccessed)
                return "true";

            return "false";
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            return Ok(user);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            MailConfirmViewModel mailConfirmViewModel = this.GetMailObject(result.ResultObj);
            await _emailConfirmService.SendMail(mailConfirmViewModel);

            return Ok(result);
        }

        [NonAction]
        public MailConfirmViewModel GetMailObject(UserViewModel userViewModel)
        {
            MailConfirmViewModel mailConfirmViewModel = new MailConfirmViewModel();
            mailConfirmViewModel.Subject = "Mail Confirmation";
            mailConfirmViewModel.Body = _emailConfirmService.GetMailBody(userViewModel);
            mailConfirmViewModel.ToMailIds = new List<string>()
            {
                userViewModel.Email
            };
            return mailConfirmViewModel;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);

            if(!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("RoleAssign/{id}")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetPagingUserManagements")]
        public async Task<IActionResult> GetPagingUserManagements([FromQuery] PagingRequestBase request)
        {
            var users = await _userService.GetPagingUserManagements(request);

            return Ok(users);
        }
    }
}
