using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IExamRepository
    {
        public Task<List<ExamVM>> GetAllExams();

        public Task<ExamVM> GetExamById(int id);

        public Task AddExam(ExamVM examVM);

        public Task UpdateExam(ExamVM examVM);

        public Task DeleteExam(int id);
    }
}
