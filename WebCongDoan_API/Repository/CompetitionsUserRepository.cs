using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionsUserRepository : ICompetitionsUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionsUserRepository(MyDBContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCompetitionsUser(CompetitionsUserVM comUVM)
        {
            var comU = _mapper.Map<CompetitionsUser>(comUVM);
            _context.CompetitionsUsers.Add(comU);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompetitionsUser(int id)
        {
            var comU = _context.CompetitionsUsers.SingleOrDefault(cu => cu.Cuid == id);
            _context.CompetitionsUsers.Remove(comU);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionsUserVM>> GetAllCompetitionsUsers()
        {
            var comUs = await _context.CompetitionsUsers.ToListAsync();
            return _mapper.Map<List<CompetitionsUserVM>>(comUs);
        }

        public async Task<CompetitionsUserVM> GetCompetitionUserById(int id)
        {
            var comU = await _context.CompetitionsUsers.FindAsync(id);
            return _mapper.Map<CompetitionsUserVM>(comU);
        }

        public async Task UpdateCompetitionsUser(CompetitionsUserVM comUVM)
        {
            var comU = _mapper.Map<CompetitionsUser>(comUVM);
            _context.CompetitionsUsers.Update(comU);
            await _context.SaveChangesAsync();
        }
    }
}
