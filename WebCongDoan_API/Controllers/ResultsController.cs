using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepository _resultRepo;

        public ResultsController(IResultRepository repo)
        {
            _resultRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _resultRepo.GetAllResults());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _resultRepo.GetResultById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("GetByComUserId")]
        public async Task<IActionResult> GetByCUId(int id)
        {
            var result = await _resultRepo.GetResultByCUId(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ResultVM resultVM)
        {
            await _resultRepo.AddResult(resultVM);
            return StatusCode(StatusCodes.Status201Created, resultVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ResultVM resultVM)
        {
            var result = await _resultRepo.GetResultById(resultVM.ResId);
            if (result == null)
                return NotFound();

            await _resultRepo.UpdateResult(resultVM);
            return Ok(resultVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _resultRepo.GetResultById(id);
            if (result == null)
                return NotFound();

            await _resultRepo.DeleteResult(id);
            return Ok();
        }
    }
}
