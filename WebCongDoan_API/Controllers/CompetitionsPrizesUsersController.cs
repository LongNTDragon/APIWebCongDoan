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
    public class CompetitionsPrizesUsersController : ControllerBase
    {
        private readonly ICompetitionsPrizesUsersRepository _comPURepo;

        public CompetitionsPrizesUsersController(ICompetitionsPrizesUsersRepository repo)
        {
            _comPURepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comPURepo.GetAllCompetitionsPrizesUsers());
        }

        [HttpGet("GetAllByCPID")]
        public async Task<IActionResult> Get(int id)
        {
            var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(id);
            if (comPU == null)
                return NotFound();

            return Ok(await _comPURepo.GetAllCompetitionsPrizesUsersByCPID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsPrizesUsersVM comPUVM)
        {
            await _comPURepo.AddCompetitionsPrizesUsers(comPUVM);
            return StatusCode(StatusCodes.Status201Created, comPUVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsPrizesUsersVM comPUVM)
        {
            var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(comPUVM.Id);
            if (comPU == null)
                return NotFound();

            await _comPURepo.UpdateCompetitionsPrizesUsers(comPUVM);
            return Ok(comPUVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(id);
            if (comPU == null)
                return NotFound();

            await _comPURepo.DeleteCompetitionsPrizesUsers(id);
            return Ok();
        }
    }
}
