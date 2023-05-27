using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionsUserRepository
    {
        public Task<List<CompetitionsUserVM>> GetAllCompetitionsUsers();

        public Task<CompetitionsUserVM> GetCompetitionUserById(int id);

        public Task AddCompetitionsUser(CompetitionsUserVM comUVM);

        public Task UpdateCompetitionsUser(CompetitionsUserVM comUVM);

        public Task DeleteCompetitionsUser(int id);
    }
}
