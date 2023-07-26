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
    public class CompetitionsBlogsUsersController : ControllerBase
    {
        private readonly ICompetitionsBlogsUserRepository _cbuRepo;

        public CompetitionsBlogsUsersController(ICompetitionsBlogsUserRepository repo)
        {
            _cbuRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cbuRepo.GetAllComBlogUsers());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cbu = await _cbuRepo.GetComBlogUserById(id);
            return cbu == null ? NotFound() : Ok(cbu);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsBlogsUserVM cbuVM)
        {
            await _cbuRepo.AddComBlogUser(cbuVM);
            return StatusCode(StatusCodes.Status201Created, cbuVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsBlogsUserVM cbuVM)
        {
            var cbu = await _cbuRepo.GetComBlogUserById(cbuVM.Id);
            if (cbu == null)
                return NotFound();

            await _cbuRepo.UpdateComBlogUser(cbuVM);
            return Ok(cbuVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cbu = await _cbuRepo.GetComBlogUserById(id);
            if (cbu == null)
                return NotFound();

            await _cbuRepo.DeleteComBlogUser(id);
            return Ok();
        }
    }
}
