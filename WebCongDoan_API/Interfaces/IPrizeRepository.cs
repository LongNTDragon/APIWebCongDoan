using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IPrizeRepository
    {
        public Task<List<PrizeVM>> GetAllPrizes();

        public Task<PrizeVM> GetPrizeById(int id);

        public Task AddPrize(PrizeVM priVM);

        public Task UpdatePrize(PrizeVM priVM);

        public Task DeletePrize(int id);
    }
}
