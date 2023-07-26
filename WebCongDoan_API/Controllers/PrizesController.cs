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
    public class PrizesController : ControllerBase
    {
        private readonly IPrizeRepository _priRepo;

        public PrizesController(IPrizeRepository repo)
        {
            _priRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _priRepo.GetAllPrizes());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var prize = await _priRepo.GetPrizeById(id);
            return prize == null ? NotFound() : Ok(prize);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PrizeVM priVM)
        {
            await _priRepo.AddPrize(priVM);
            return StatusCode(StatusCodes.Status201Created, priVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PrizeVM priVM)
        {
            var prize = await _priRepo.GetPrizeById(priVM.PriId);
            if (prize == null)
                return NotFound();

            await _priRepo.UpdatePrize(priVM);
            return Ok(priVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var prize = await _priRepo.GetPrizeById(id);
            if (prize == null)
                return NotFound();

            await _priRepo.DeletePrize(id);
            return Ok();
        }
    }
}
