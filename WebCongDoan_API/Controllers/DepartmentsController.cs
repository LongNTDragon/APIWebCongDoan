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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _depRepo;

        public DepartmentsController(IDepartmentRepository repo)
        {
            _depRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _depRepo.GetAllDepartments());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var dep = await _depRepo.GetDepartmentById(id);
            return dep == null ? NotFound() : Ok(dep);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DepartmentVM depVM)
        {
            await _depRepo.AddDepartment(depVM);
            return StatusCode(StatusCodes.Status201Created, depVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentVM depVM)
        {
            var dep = await _depRepo.GetDepartmentById(depVM.DepId);
            if (dep == null)
                return NotFound();

            await _depRepo.UpdateDepartment(depVM);
            return Ok(depVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await _depRepo.GetDepartmentById(id);
            if (dep == null)
                return NotFound();

            await _depRepo.DeleteDepartment(id);
            return Ok();
        }
    }
}
