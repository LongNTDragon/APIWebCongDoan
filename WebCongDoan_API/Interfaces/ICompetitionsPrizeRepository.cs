using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionsPrizeRepository
    {
        public Task<List<CompetitionsPrizeVM>> GetAllCompetitionsPrizes();

        public Task<CompetitionsPrizeVM> GetCompetitionsPrizeById(int id);

        public Task AddCompetitionsPrize(CompetitionsPrizeVM comPVM);

        public Task UpdateCompetitionsPrize(CompetitionsPrizeVM comPVM);

        public Task DeleteCompetitionsPrize(int id);
    }
}
