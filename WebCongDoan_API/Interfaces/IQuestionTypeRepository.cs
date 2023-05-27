using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IQuestionTypeRepository
    {
        public Task<List<QuestionTypeVM>> GetAllQuestionTypes();

        public Task<QuestionTypeVM> GetQuestionTypeById(int id);

        public Task AddQuestionType(QuestionTypeVM quesTVM);

        public Task UpdateQuestionType(QuestionTypeVM quesTVM);

        public Task DeleteQuestionType(int id);
    }
}
