using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepo;

        public RolesController(IRoleRepository repo)
        {
            _roleRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roleRepo.GetAllRoles());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleRepo.GetRoleById(id);
            return role == null ? NotFound() : Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(RoleVM roleVM)
        {
            await _roleRepo.AddRole(roleVM);
            return StatusCode(StatusCodes.Status201Created, roleVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleVM roleVM)
        {
            var role = await _roleRepo.GetRoleById(roleVM.RoleId);
            if (role == null)
                return NotFound();
            
            await _roleRepo.UpdateRole(roleVM);
            return Ok(roleVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleRepo.GetRoleById(id);
            if (role == null)
                return NotFound();
            
            await _roleRepo.DeleteRole(id);
            return Ok();
        }
    }
}
