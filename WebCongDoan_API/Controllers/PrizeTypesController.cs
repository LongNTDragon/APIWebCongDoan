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
    public class PrizeTypesController : ControllerBase
    {
        private readonly IPrizeTypeRepository _priTRepo;

        public PrizeTypesController(IPrizeTypeRepository repo) 
        {
            _priTRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _priTRepo.GetAllPrizeTypes());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var priT = await _priTRepo.GetPrizeTypeById(id);
            return priT == null ? NotFound() : Ok(priT);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PrizeTypeVM priTVM)
        {
            await _priTRepo.AddPrizeType(priTVM);
            return StatusCode(StatusCodes.Status201Created, priTVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PrizeTypeVM priTVM)
        {
            var priT = await _priTRepo.GetPrizeTypeById(priTVM.PriTid);
            if (priT == null)
                return NotFound();

            await _priTRepo.UpdatePrizeType(priTVM);
            return Ok(priTVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var priT = await _priTRepo.GetPrizeTypeById(id);
            if (priT == null)
                return NotFound();

            await _priTRepo.DeletePrizeType(id);
            return Ok();
        }
    }
}
