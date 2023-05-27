using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ExamRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddExam(ExamVM examVM)
        {
            var exam = _mapper.Map<Exam>(examVM);
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int id)
        {
            var exam = _context.Exams.SingleOrDefault(e => e.ExamId == id);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExamVM>> GetAllExams()
        {
            var exams = await _context.Exams.ToListAsync();
            return _mapper.Map<List<ExamVM>>(exams);
        }

        public async Task<ExamVM> GetExamById(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            return _mapper.Map<ExamVM>(exam);
        }

        public async Task UpdateExam(ExamVM examVM)
        {
            var exam = _mapper.Map<Exam>(examVM);
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}
