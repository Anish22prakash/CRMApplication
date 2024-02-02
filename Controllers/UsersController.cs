using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationshipManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost, Route("RegisterUser")]
        [Consumes("multipart/form-data")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> AddUser([FromForm] UserRegisterDto usersDto)
        {
            if (!string.IsNullOrWhiteSpace(usersDto.UserEmail) || !string.IsNullOrWhiteSpace(usersDto.UserMobile))
            {

                var data = await _userService.RegisterUserAsync(usersDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to add user" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Email/mobile is not valid" });
            }
        }

        [HttpPost, Route("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLoginDto usersDto)
        {
            if (!string.IsNullOrWhiteSpace(usersDto.UserEmail) && !string.IsNullOrWhiteSpace(usersDto.UserPassword))
            {

                var data = await _userService.loginUserAsync(usersDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Failed to login, check user credentials" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Something went wrong" });
            }
        }

        [HttpGet, Route("GetAllUserByFilter")]
        public async Task<IActionResult> GetAllUserByFilter(int page = 1, int pageSize = 10, string? search = "")
        {
            try
            {
                var data = await _userService.GetAllUserByFilter(page, pageSize, search);
                if (data.Count > 0)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "not users found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

        [HttpGet, Route("GetUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (userId > 0)
            {
                var data = await _userService.GetUserAsync(userId);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "unable to find user" });
                }
            }
            else
            {
                return BadRequest(new { success = false, statusCode = 400, error = "userId not valid" });
            }
        }
    }
}
