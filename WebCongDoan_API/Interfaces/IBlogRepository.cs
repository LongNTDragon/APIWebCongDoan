using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IBlogRepository
    {
        public Task AddBlog(BlogVM blogVM);

        public Task DeleteBlog(int id);

        public Task<List<BlogVM>> GetAllBlog();

        public Task<BlogVM> GetBlogById(int id);

        public Task UpdateBlog(BlogVM blogVM);
        
    }
}
