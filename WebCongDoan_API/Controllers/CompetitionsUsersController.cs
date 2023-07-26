using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsUsersController : ControllerBase
    {
        private readonly ICompetitionsUserRepository _comURepo;

        public CompetitionsUsersController(ICompetitionsUserRepository repo)
        {
            _comURepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comURepo.GetAllCompetitionsUsers());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var comU = await _comURepo.GetCompetitionUserById(id);
            return comU == null ? NotFound() : Ok(comU);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsUserVM comUVM)
        {
            await _comURepo.AddCompetitionsUser(comUVM);
            return StatusCode(StatusCodes.Status201Created, comUVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsUserVM comUVM)
        {
            var comU = await _comURepo.GetCompetitionUserById(comUVM.Cuid);
            if (comU == null)
                return NotFound();

            await _comURepo.UpdateCompetitionsUser(comUVM);
            return Ok(comUVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comU = await _comURepo.GetCompetitionUserById(id);
            if (comU == null)
                return NotFound();

            await _comURepo.DeleteCompetitionsUser(id);
            return Ok();
        }
    }
}
