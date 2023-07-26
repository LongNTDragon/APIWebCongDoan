using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _quesRepo;

        public QuestionsController(IQuestionRepository repo)
        {
            _quesRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _quesRepo.GetAllQuestions());
        }

        [HttpGet("GetAllByExamID")]
        public async Task<IActionResult> GetAllByExamID(int id)
        {
            return Ok(await _quesRepo.GetAllQuestionByExamId(id));
        }

        [HttpGet("GetByQuesId")]
        public async Task<IActionResult> GetByQuesId(int id)
        {
            var ques = await _quesRepo.GetQuestionByQuesId(id);
            return ques == null ? NotFound() : Ok(ques);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(QuestionVM quesVM)
        {
            await _quesRepo.AddQuestion(quesVM);
            return StatusCode(StatusCodes.Status201Created, quesVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(QuestionVM quesVM)
        {
            var ques = await _quesRepo.GetQuestionByQuesId(quesVM.QuesId);
            if (ques == null)
                return NotFound();

            await _quesRepo.UpdateQuestion(quesVM);
            return Ok(quesVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var ques = await _quesRepo.GetQuestionByQuesId(id);
            if (ques == null)
                return NotFound();

            await _quesRepo.DeleteQuestion(id);
            return Ok();
        }
    }
}
