using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<List<QuestionVM>> GetAllQuestions();

        public Task<QuestionVM> GetQuestionByQuesId(int id);

        public Task<QuestionVM> GetQuestionByComId(int id);

        public Task AddQuestion(QuestionVM quesVM);

        public Task UpdateQuestion(QuestionVM quesVM);

        public Task DeleteQuestion(int id);
    }
}
