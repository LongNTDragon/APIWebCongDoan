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
    public class PickerQuestionsController : ControllerBase
    {
        private readonly IPickerQuestionRepository _pickRepo;

        public PickerQuestionsController(IPickerQuestionRepository repo)
        {
            _pickRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _pickRepo.GetAllPickerQuestions());
        }

        [HttpGet("GetAllByComUserId")]
        public async Task<IActionResult> GetAllByCUId(int id)
        {
            return Ok(await _pickRepo.GetAllPickerQuestionsByCUId(id));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var pickQ = await _pickRepo.GetPickerQuestionById(id);
            return pickQ == null ? NotFound() : Ok(pickQ);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PickerQuestionVM pickQVM)
        {
            await _pickRepo.AddPickerQuestion(pickQVM);
            return StatusCode(StatusCodes.Status201Created, pickQVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PickerQuestionVM pickQVM)
        {
            var pickQ = await _pickRepo.GetPickerQuestionById(pickQVM.Pqid);
            if (pickQ == null)
                return NotFound();

            await _pickRepo.UpdatePickerQuestion(pickQVM);
            return Ok(pickQVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var pickQ = await _pickRepo.GetPickerQuestionById(id);
            if (pickQ == null)
                return NotFound();

            await _pickRepo.DeletePickerQuestion(id);
            return Ok();
        }
    }
}
