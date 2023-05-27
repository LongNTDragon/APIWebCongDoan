using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IPrizeTypeRepository
    {
        public Task<List<PrizeTypeVM>> GetAllPrizeTypes();

        public Task<PrizeTypeVM> GetPrizeTypeById(int id);

        public Task AddPrizeType(PrizeTypeVM priTVM);

        public Task UpdatePrizeType(PrizeTypeVM priTVM);

        public Task DeletePrizeType(int id);
    }
}
