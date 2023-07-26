using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private IConfiguration _configuration;

        public UsersController(IUserRepository repo, IConfiguration configuration)
        {
            _userRepo = repo;
            _configuration = configuration;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
            if (id == null) 
                throw new Exception("authorize");
            return Ok(await _userRepo.GetUserById(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userRepo.GetAllUsers());
        }

        [HttpGet("GetAllByDepID")]
        public async Task<IActionResult> GetAllByDepID(int id)
        {
            return Ok(await _userRepo.GetAllUsersByDepID(id));
        }

        [HttpGet("GetAllByRoleID")]
        public async Task<IActionResult> GetAllByRoleID(int id)
        {
            return Ok(await _userRepo.GetAllUsersByRoleID(id));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(String id)
        {
            var user = await _userRepo.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(RegisterVM registerVM)
        {
            await _userRepo.AddUser(registerVM);
            return StatusCode(StatusCodes.Status201Created, registerVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserVM userVM)
        {
            var user = await _userRepo.GetUserById(userVM.UserId);
            if (user == null)
                return NotFound();

            await _userRepo.UpdateUser(userVM);
            return Ok(userVM);
        }

        [HttpPut("UpdateIsDeleted")]
        public async Task<IActionResult> UpdateIsDeleted(string id, int value)
        {
            var user = await _userRepo.GetUserById(id);
            if (user == null)
                return NotFound();

            await _userRepo.UpdateIsDeletedByUserID(id, value);
            var newUser = await _userRepo.GetUserById(id);
            return Ok(newUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(String id)
        {
            var user = await _userRepo.GetUserById(id);
            if (user == null)
                return NotFound();

            await _userRepo.DeleteUser(id);
            return Ok();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckUser(LoginVM loginVM)
        {
            var token = await _userRepo.GetUserByEmailAndPass(loginVM);
            Response.Cookies.Append(
                _configuration["KEY_COOKIE_AUTH"],
                token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

            return Ok("Login success");
        }

        [HttpGet("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete(_configuration["KEY_COOKIE_AUTH"]);
            return Ok("Logout success");
        }
    }
}
