using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin +","+ UserRole.Manager)]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepo;

        public ExamsController(IExamRepository repo)
        {
            _examRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _examRepo.GetAllExams());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var exam = await _examRepo.GetExamById(id);
            return exam == null ? NotFound() : Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ExamVM examVM)
        {
            await _examRepo.AddExam(examVM);
            return StatusCode(StatusCodes.Status201Created, examVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ExamVM examVM)
        {
            var exam = await _examRepo.GetExamById(examVM.ExamId);
            if (exam == null)
                return NotFound();

            await _examRepo.UpdateExam(examVM);
            return Ok(examVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var exam = await _examRepo.GetExamById(id);
            if (exam == null)
                return NotFound();

            await _examRepo.DeleteExam(id);
            return Ok();
        }
    }
}
