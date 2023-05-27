using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IResultRepository
    {
        public Task<List<ResultVM>> GetAllResults();

        public Task<ResultVM> GetResultById(int id);

        public Task<ResultVM> GetResultByCUId(int id);

        public Task AddResult(ResultVM resultVM);

        public Task UpdateResult(ResultVM resultVM);

        public Task DeleteResult(int id);
    }
}
