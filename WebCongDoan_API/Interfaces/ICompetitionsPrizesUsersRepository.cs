using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionsPrizesUsersRepository
    {
        public Task<List<CompetitionsPrizesUsersVM>> GetAllCompetitionsPrizesUsers();

        public Task<List<CompetitionsPrizesUsersVM>> GetAllCompetitionsPrizesUsersByCPID(int id);

        public Task<CompetitionsPrizesUsersVM> GetCompetitionsPrizesUsersByID(int id);

        public Task AddCompetitionsPrizesUsers(CompetitionsPrizesUsersVM comPUVM);

        public Task UpdateCompetitionsPrizesUsers(CompetitionsPrizesUsersVM comPUVM);

        public Task DeleteCompetitionsPrizesUsers(int id);
    }
}
