using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;
using WebCongDoan_API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepo;

        public BlogsController(IBlogRepository repo) 
        {
            _blogRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _blogRepo.GetAllBlog());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogRepo.GetBlogById(id);
            return blog == null ? NotFound() : Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BlogVM blogVM)
        {
            await _blogRepo.AddBlog(blogVM);
            return StatusCode(StatusCodes.Status201Created, blogVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BlogVM blogVM)
        {
            var blog = await _blogRepo.GetBlogById(blogVM.BlogId);
            if (blog == null)
                return NotFound();

            await _blogRepo.UpdateBlog(blogVM);
            return Ok(blogVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogRepo.GetBlogById(id);
            if (blog == null)
                return NotFound();

            await _blogRepo.DeleteBlog(id);
            return Ok();
        }
    }
}
