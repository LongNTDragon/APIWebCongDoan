using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionsBlogsUserRepository : ICompetitionsBlogsUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionsBlogsUserRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddComBlogUser(CompetitionsBlogsUserVM cbuVM)
        {
            var cbu = _mapper.Map<CompetitionsBlogsUser>(cbuVM);
            _context.CompetitionsBlogsUsers.Add(cbu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComBlogUser(int id)
        {
            var cbu = _context.CompetitionsBlogsUsers.SingleOrDefault(c => c.Id == id);
            _context.CompetitionsBlogsUsers.Remove(cbu);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionsBlogsUserVM>> GetAllComBlogUsers()
        {
            var cbus = await _context.CompetitionsBlogsUsers.ToListAsync();
            return _mapper.Map<List<CompetitionsBlogsUserVM>>(cbus);
        }

        public async Task<CompetitionsBlogsUserVM> GetComBlogUserById(int id)
        {
            var cbu = await _context.CompetitionsBlogsUsers.FindAsync(id);
            return _mapper.Map<CompetitionsBlogsUserVM>(cbu);
        }

        public async Task UpdateComBlogUser(CompetitionsBlogsUserVM cbuVM)
        {
            var cbu = _mapper.Map<CompetitionsBlogsUser>(cbuVM);
            _context.CompetitionsBlogsUsers.Update(cbu);
            await _context.SaveChangesAsync();
        }
    }
}
