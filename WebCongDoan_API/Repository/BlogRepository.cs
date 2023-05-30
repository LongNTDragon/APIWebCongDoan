using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Models;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class BlogRepository:IBlogRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddBlog(BlogVM blogVM)
        {
            var blog = new Blog();
            blog.BlogName = blogVM.BlogName;
            blog.BlogDetai = blogVM.BlogDetai;
            blog.ImgName = blogVM.ImgName;
            blog.ImgSrc = blogVM.ImgSrc;

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlog(int id)
        {
            var blog = _context.Blogs.SingleOrDefault(b =>b.BlogId == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BlogVM>>GetAllBlog()
        {
            var blog = await _context.Blogs.ToListAsync();
            return _mapper.Map<List<BlogVM>>(blog);
        }

        public async Task<BlogVM> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            return _mapper.Map<BlogVM>(blog);
        }

        public async Task UpdateBlog(BlogVM blogVM)
        {
            var blog = _context.Blogs.SingleOrDefault(b => b.BlogId == blogVM.BlogId);
            blog.BlogName = blogVM.BlogName;
            blog.BlogDetai = blogVM.BlogDetai;
            blog.ImgName = blogVM.ImgName;
            blog.ImgSrc = blogVM.ImgSrc;

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }
    }
}
