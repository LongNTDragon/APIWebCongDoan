using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class PrizeTypeRepository : IPrizeTypeRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public PrizeTypeRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddPrizeType(PrizeTypeVM priTVM)
        {
            var priT = new PrizeType();
            priT.PriTname = priTVM.PriTname;

            _context.PrizeTypes.Add(priT);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrizeType(int id)
        {
            var priT = _context.PrizeTypes.SingleOrDefault(p=>p.PriTid == id);
            _context.PrizeTypes.Remove(priT);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrizeTypeVM>> GetAllPrizeTypes()
        {
            var priTs = await _context.PrizeTypes.ToListAsync();
            return _mapper.Map<List<PrizeTypeVM>>(priTs);
        }

        public async Task<PrizeTypeVM> GetPrizeTypeById(int id)
        {
            var priT = await _context.PrizeTypes.FindAsync(id);
            return _mapper.Map<PrizeTypeVM>(priT);
        }

        public async Task UpdatePrizeType(PrizeTypeVM priTVM)
        {
            var priT = _context.PrizeTypes.SingleOrDefault(pt => pt.PriTid == priTVM.PriTid);
            priT.PriTname = priTVM.PriTname;

            _context.PrizeTypes.Update(priT);
            await _context.SaveChangesAsync();
        }
    }
}
