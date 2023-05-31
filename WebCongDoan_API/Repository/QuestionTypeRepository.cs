using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public QuestionTypeRepository(MyDBContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task AddQuestionType(QuestionTypeVM quesTVM)
        {
            var quesT = new QuestionType();
            quesT.QuesTName = quesTVM.QuesTName;

            _context.QuestionTypes.Add(quesT);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionType(int id)
        {
            var quesT = _context.QuestionTypes.SingleOrDefault(q => q.QuesTId == id);
            _context.QuestionTypes.Remove(quesT);
            await _context.SaveChangesAsync();
        }

        public async Task<List<QuestionTypeVM>> GetAllQuestionTypes()
        {
            var quesTs = await _context.QuestionTypes.ToListAsync();
            return _mapper.Map<List<QuestionTypeVM>>(quesTs);
        }

        public async Task<QuestionTypeVM> GetQuestionTypeById(int id)
        {
            var quesT = await _context.QuestionTypes.FindAsync(id);
            return _mapper.Map<QuestionTypeVM>(quesT);
        }

        public async Task UpdateQuestionType(QuestionTypeVM quesTVM)
        {
            var quesT = _context.QuestionTypes.SingleOrDefault(qt => qt.QuesTId == quesTVM.QuesTId);
            quesT.QuesTName = quesTVM.QuesTName;

            _context.QuestionTypes.Update(quesT);
            await _context.SaveChangesAsync();
        }
    }
}
