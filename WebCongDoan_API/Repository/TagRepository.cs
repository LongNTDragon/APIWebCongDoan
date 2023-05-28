using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class TagRepository:ITagRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public TagRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddTag(TagVM tagVM)
        {
            var tag = _mapper.Map<Tag>(tagVM);
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(int id)
        {
            var tag = _context.Tags.SingleOrDefault(p => p.TagId == id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TagVM>> GetAllTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return _mapper.Map<List<TagVM>>(tags);
        }

        public async Task<List<TagVM>> GetAllTagsByBlogID(int id)
        {
            var tags = await _context.Tags.Where(t => t.BlogId == id).ToListAsync();
            return _mapper.Map<List<TagVM>>(tags);
        }

        public async Task<TagVM> GetTagById(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            return _mapper.Map<TagVM>(tag);
        }

        public async Task UpdateTag(TagVM tagVM)
        {
            var tag = _mapper.Map<Tag>(tagVM);
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }
    }
}
