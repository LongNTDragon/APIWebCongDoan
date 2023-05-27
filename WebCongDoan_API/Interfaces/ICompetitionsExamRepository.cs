using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionsExamRepository
    {
        public Task<List<CompetitionsExamVM>> GetAllompetitionsExams();

        public Task<List<CompetitionsExamVM>> GetAllompetitionsExamsByComID(int id);

        public Task<CompetitionsExamVM> GetCompetitionsExamById(int id);

        public Task AddCompetitionsExam(CompetitionsExamVM comEVM);

        public Task UpdateCompetitionsExam(CompetitionsExamVM comEVM);

        public Task DeleteCompetitionExam(int id);
    }
}
