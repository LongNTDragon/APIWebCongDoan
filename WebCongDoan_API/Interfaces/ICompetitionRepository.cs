using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionRepository
    {
        public Task<List<CompetitionVM>> GetAllCompetitions();

        public Task<CompetitionVM> GetCompetitionById(int id);

        public Task AddCompetition(CompetitionVM comVM);

        public Task UpdateCompetition(CompetitionVM comVM);

        public Task DeleteCompetition(int id);

        public Task UpdateIsDeletedByComID(int id, int value);
    }
}
