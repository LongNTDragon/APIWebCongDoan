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
    public class QuestionTypesController : ControllerBase
    {
        
        private readonly IQuestionTypeRepository _quesTRepo;

        public QuestionTypesController(IQuestionTypeRepository repo)
        {
            _quesTRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _quesTRepo.GetAllQuestionTypes());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var quesT = await _quesTRepo.GetQuestionTypeById(id);
            return quesT == null ? NotFound() : Ok(quesT);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(QuestionTypeVM quesTVM)
        {
            await _quesTRepo.AddQuestionType(quesTVM);
            return StatusCode(StatusCodes.Status201Created, quesTVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(QuestionTypeVM quesTVM)
        {
            var quesT = await _quesTRepo.GetQuestionTypeById(quesTVM.QuesTId);
            if (quesT == null)
                return NotFound();

            await _quesTRepo.UpdateQuestionType(quesTVM);
            return Ok(quesTVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var quesT = await _quesTRepo.GetQuestionTypeById(id);
            if (quesT == null)
                return NotFound();

            await _quesTRepo.DeleteQuestionType(id);
            return Ok();
        }
    }
}
