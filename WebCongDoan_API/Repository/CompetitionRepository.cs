using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCompetition(CompetitionVM comVM)
        {
            var com = new Competition();
            com.ComName = comVM.ComName;
            com.ExamTimes = comVM.ExamTimes;
            com.StartDate = comVM.StartDate;
            com.EndDate = comVM.EndDate;
            com.UserQuan = comVM.UserQuan;
            com.DepId = comVM.DepId;

            _context.Competitions.Add(com);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompetition(int id)
        {
            var com = _context.Competitions.SingleOrDefault(c => c.ComId == id);
            _context.Competitions.Remove(com);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionVM>> GetAllCompetitions()
        {
            var coms = await _context.Competitions.ToListAsync();
            return _mapper.Map <List<CompetitionVM>>(coms);
        }

        public async Task<CompetitionVM> GetCompetitionById(int id)
        {
            var com = await _context.Competitions.FindAsync(id);
            return _mapper.Map<CompetitionVM>(com);
        }

        public async Task UpdateCompetition(CompetitionVM comVM)
        {
            var com = _context.Competitions.SingleOrDefault(c => c.ComId == comVM.ComId);
            com.ComName = comVM.ComName;
            com.ExamTimes = comVM.ExamTimes;
            com.StartDate = comVM.StartDate;
            com.EndDate = comVM.EndDate;
            com.UserQuan = comVM.UserQuan;
            com.DepId = comVM.DepId;

            _context.Competitions.Update(com);
            await _context.SaveChangesAsync();
        }
    }
}
