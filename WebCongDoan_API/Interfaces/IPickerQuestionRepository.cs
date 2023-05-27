using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IPickerQuestionRepository
    {
        public Task<List<PickerQuestionVM>> GetAllPickerQuestions();

        public Task<List<PickerQuestionVM>> GetAllPickerQuestionsByCUId(int id);

        public Task<PickerQuestionVM> GetPickerQuestionById(int id);

        public Task AddPickerQuestion(PickerQuestionVM pickQVM);

        public Task UpdatePickerQuestion(PickerQuestionVM pickQVM);

        public Task DeletePickerQuestion(int id);
    }
}
