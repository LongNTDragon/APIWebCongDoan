using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public QuestionRepository(MyDBContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task AddQuestion(QuestionVM quesVM)
        {
            var ques = new Question();
            ques.QuesDetail = quesVM.QuesDetail;
            ques.AnsOfQues = quesVM.AnsOfQues;
            ques.TrueAnswer = quesVM.TrueAnswer;
            ques.ExamId = quesVM.ExamId;
            ques.QuesTId = quesVM.QuesTId;

            _context.Questions.Add(ques);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int id)
        {
            var ques = _context.Questions.SingleOrDefault(q => q.QuesId == id);
            _context.Questions.Remove(ques);
            await _context.SaveChangesAsync();
        }

        public async Task<List<QuestionVM>> GetAllQuestions()
        {
            var quess = await _context.Questions.ToListAsync();
            return _mapper.Map<List<QuestionVM>>(quess);
        }

        public async Task<List<QuestionVM>> GetAllQuestionByExamId(int id)
        {
            var quess = await _context.Questions.Where(q => q.ExamId == id).ToListAsync();
            return _mapper.Map<List<QuestionVM>>(quess);
        }

        public async Task<QuestionVM> GetQuestionByQuesId(int id)
        {
            var ques = await _context.Questions.FindAsync(id);
            return _mapper.Map<QuestionVM>(ques);
        }

        public async Task<QuestionVM> GetQuestionByExamId(int id)
        {
            var ques = await _context.Questions.SingleOrDefaultAsync(q => q.ExamId == id);
            return _mapper.Map<QuestionVM>(ques);
        }

        public async Task UpdateQuestion(QuestionVM quesVM)
        {
            var ques = _context.Questions.SingleOrDefault(q => q.QuesId == quesVM.QuesId);
            ques.QuesDetail = quesVM.QuesDetail;
            ques.AnsOfQues = quesVM.AnsOfQues;
            ques.TrueAnswer = quesVM.TrueAnswer;
            ques.ExamId = quesVM.ExamId;
            ques.QuesTId = quesVM.QuesTId;

            _context.Questions.Update(ques);
            await _context.SaveChangesAsync();
        }
    }
}
