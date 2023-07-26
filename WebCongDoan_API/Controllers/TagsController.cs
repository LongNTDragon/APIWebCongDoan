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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _tagRepo;

        public TagsController(ITagRepository repo)
        {
            _tagRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tagRepo.GetAllTags());
        }

        [HttpGet("GetAllByBlogID")]
        public async Task<IActionResult> GetAllByBlogID(int id)
        {
            return Ok(await _tagRepo.GetAllTagsByBlogID(id));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var com = await _tagRepo.GetTagById(id);
            return com == null ? NotFound() : Ok(com);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TagVM tagVM)
        {
            await _tagRepo.AddTag(tagVM);
            return StatusCode(StatusCodes.Status201Created, tagVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TagVM tagVM)
        {
            var com = await _tagRepo.GetTagById(tagVM.TagId);
            if (com == null)
                return NotFound();

            await _tagRepo.UpdateTag(tagVM);
            return Ok(tagVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagRepo.GetTagById(id);
            if (tag == null)
                return NotFound();

            await _tagRepo.DeleteTag(id);
            return Ok();
        }
    }
}
