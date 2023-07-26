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
    public class CompetitionsController : ControllerBase
    {
        private readonly ICompetitionRepository _comRepo;

        public CompetitionsController(ICompetitionRepository repo) 
        {
            _comRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comRepo.GetAllCompetitions());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var com = await _comRepo.GetCompetitionById(id);
            return com == null ? NotFound() : Ok(com);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionVM comVM)
        {
            await _comRepo.AddCompetition(comVM);
            return StatusCode(StatusCodes.Status201Created, comVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionVM comVM)
        {
            var com = await _comRepo.GetCompetitionById(comVM.ComId);
            if (com == null)
                return NotFound();

            await _comRepo.UpdateCompetition(comVM);
            return Ok(comVM);
        }

        [HttpPut("UpdateIsDeleted")]
        public async Task<IActionResult> UpdateIsDeleted(int id, int value)
        {
            var com = await _comRepo.GetCompetitionById(id);
            if (com == null)
                return NotFound();

            await _comRepo.UpdateIsDeletedByComID(id, value);
            var newCom = await _comRepo.GetCompetitionById(id);
            return Ok(newCom);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var com = await _comRepo.GetCompetitionById(id);
            if (com == null)
                return NotFound();

            await _comRepo.DeleteCompetition(id);
            return Ok();
        }
    }
}
