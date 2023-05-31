using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class PickerQuestionRepository : IPickerQuestionRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public PickerQuestionRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddPickerQuestion(PickerQuestionVM pickQVM)
        {
            var pickQ = new PickerQuestion();
            pickQ.Cuid = pickQVM.Cuid;
            pickQ.QuesId = pickQVM.QuesId;
            pickQ.Answer = pickQVM.Answer;

            _context.PickerQuestions.Add(pickQ);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePickerQuestion(int id)
        {
            var pickQ = _context.PickerQuestions.SingleOrDefault(p => p.Pqid == id);
            _context.PickerQuestions.Remove(pickQ);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PickerQuestionVM>> GetAllPickerQuestions()
        {
            var pickQs = await _context.PickerQuestions.ToListAsync();
            return _mapper.Map<List<PickerQuestionVM>>(pickQs);
        }

        public async Task<List<PickerQuestionVM>> GetAllPickerQuestionsByCUId(int id)
        {
            var pickQs = await _context.PickerQuestions.Where(p => p.Cuid == id).ToListAsync();
            return _mapper.Map<List<PickerQuestionVM>>(pickQs);
        }

        public async Task<PickerQuestionVM> GetPickerQuestionById(int id)
        {
            var pickQ = await _context.PickerQuestions.FindAsync(id);
            return _mapper.Map<PickerQuestionVM>(pickQ);
        }

        public async Task UpdatePickerQuestion(PickerQuestionVM pickQVM)
        {
            var pickQ = _context.PickerQuestions.SingleOrDefault(p => p.Pqid == pickQVM.Pqid);
            pickQ.Cuid = pickQVM.Cuid;
            pickQ.QuesId = pickQVM.QuesId;
            pickQ.Answer = pickQVM.Answer;

            _context.PickerQuestions.Update(pickQ);
            await _context.SaveChangesAsync();
        }
    }
}
