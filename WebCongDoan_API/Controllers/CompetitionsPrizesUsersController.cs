using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return Ok(await _comPURepo.GetAllCompetitionsPrizesUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllByCPID")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(id);
                if (comPU == null)
                    return NotFound();

                return Ok(await _comPURepo.GetAllCompetitionsPrizesUsersByCPID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsPrizesUsersVM comPUVM)
        {
            try
            {
                await _comPURepo.AddCompetitionsPrizesUsers(comPUVM);
                return StatusCode(StatusCodes.Status201Created, comPUVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsPrizesUsersVM comPUVM)
        {
            try
            {
                var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(comPUVM.Id);
                if (comPU == null)
                    return NotFound();

                await _comPURepo.UpdateCompetitionsPrizesUsers(comPUVM);
                return Ok(comPUVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comPU = await _comPURepo.GetCompetitionsPrizesUsersByID(id);
                if (comPU == null)
                    return NotFound();

                await _comPURepo.DeleteCompetitionsPrizesUsers(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
