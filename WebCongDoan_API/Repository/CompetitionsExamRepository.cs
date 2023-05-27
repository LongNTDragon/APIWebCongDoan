using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionsExamRepository : ICompetitionsExamRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionsExamRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCompetitionsExam(CompetitionsExamVM comEVM)
        {
            var comE = _mapper.Map<CompetitionsExam>(comEVM);
            _context.CompetitionsExams.Add(comE);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompetitionExam(int id)
        {
            var comE = _context.CompetitionsExams.FirstOrDefault(c => c.Ceid == id);
            _context.CompetitionsExams.Remove(comE);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionsExamVM>> GetAllompetitionsExams()
        {
            var comEs = await _context.CompetitionsExams.ToListAsync();
            return _mapper.Map<List<CompetitionsExamVM>>(comEs);
        }

        public async Task<List<CompetitionsExamVM>> GetAllompetitionsExamsByComID(int id)
        {
            var comEs = await _context.CompetitionsExams.Where(c => c.ComId == id).ToListAsync();
            return _mapper.Map<List<CompetitionsExamVM>>(comEs);
        }

        public async Task<CompetitionsExamVM> GetCompetitionsExamById(int id)
        {
            var comE = await _context.CompetitionsExams.FindAsync(id);
            return _mapper.Map<CompetitionsExamVM>(comE);
        }

        public async Task UpdateCompetitionsExam(CompetitionsExamVM comEVM)
        {
            var comE = _mapper.Map<CompetitionsExam>(comEVM);
            _context.CompetitionsExams.Update(comE);
            await _context.SaveChangesAsync();
        }
    }
}
