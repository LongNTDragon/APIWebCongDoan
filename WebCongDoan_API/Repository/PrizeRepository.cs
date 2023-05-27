using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class PrizeRepository : IPrizeRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public PrizeRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddPrize(PrizeVM priVM)
        {
            var prize = _mapper.Map<Prize>(priVM);
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrize(int id)
        {
            var prize = _context.Prizes.SingleOrDefault(p => p.PriId == id);
            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrizeVM>> GetAllPrizes()
        {
            var prizes = await _context.Prizes.ToListAsync();
            return _mapper.Map<List<PrizeVM>>(prizes);
        }

        public async Task<PrizeVM> GetPrizeById(int id)
        {
            var prize = await _context.Prizes.FindAsync(id);
            return _mapper.Map<PrizeVM>(prize);
        }

        public async Task UpdatePrize(PrizeVM priVM)
        {
            var prize = _mapper.Map<Prize>(priVM);
            _context.Prizes.Update(prize);
            await _context.SaveChangesAsync();
        }
    }
}
