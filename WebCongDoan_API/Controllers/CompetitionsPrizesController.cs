using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsPrizesController : ControllerBase
    {
        private readonly ICompetitionsPrizeRepository _comPriRepo;

        public CompetitionsPrizesController(ICompetitionsPrizeRepository repo)
        {
            _comPriRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comPriRepo.GetAllCompetitionsPrizes());
        }

        [HttpGet("GetAllByComID")]
        public async Task<IActionResult> GetAllByComID(int id)
        {
            return Ok(await _comPriRepo.GetAllCompetitionsPrizesByComID(id));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var comPri = await _comPriRepo.GetCompetitionsPrizeById(id);
            return comPri == null ? NotFound() : Ok(comPri);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsPrizeVM comPVM)
        {
            await _comPriRepo.AddCompetitionsPrize(comPVM);
            return StatusCode(StatusCodes.Status201Created, comPVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsPrizeVM comPVM)
        {
            var comPri = await _comPriRepo.GetCompetitionsPrizeById(comPVM.Cpid);
            if (comPri == null)
                return NotFound();

            await _comPriRepo.UpdateCompetitionsPrize(comPVM);
            return Ok(comPVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comPri = await _comPriRepo.GetCompetitionsPrizeById(id);
            if (comPri == null)
                return NotFound();

            await _comPriRepo.DeleteCompetitionsPrize(id);
            return Ok();
        }
    }
}
