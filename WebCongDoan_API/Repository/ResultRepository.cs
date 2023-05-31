using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ResultRepository(MyDBContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task AddResult(ResultVM resultVM)
        {
            var result = new Result();
            result.TrueAns = resultVM.TrueAns;
            result.FalseAns = resultVM.FalseAns;
            result.Cuid = resultVM.Cuid;
            result.StartTimes = resultVM.StartTimes;
            result.EndTimes = resultVM.EndTimes;

            _context.Results.Add(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResult(int id)
        {
            var result = _context.Results.SingleOrDefault(r => r.ResId == id);
            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultVM>> GetAllResults()
        {
            var results = await _context.Results.ToListAsync();
            return _mapper.Map<List<ResultVM>>(results);
        }

        public async Task<ResultVM> GetResultByCUId(int id)
        {
            var result = await _context.Results.SingleOrDefaultAsync(r=>r.Cuid == id);
            return _mapper.Map<ResultVM>(result);
        }

        public async Task<ResultVM> GetResultById(int id)
        {
            var result = await _context.Results.FindAsync(id);
            return _mapper.Map<ResultVM>(result);
        }

        public async Task UpdateResult(ResultVM resultVM)
        {
            var result = _context.Results.SingleOrDefault(r => r.ResId == resultVM.ResId);
            result.TrueAns = resultVM.TrueAns;
            result.FalseAns = resultVM.FalseAns;
            result.Cuid = resultVM.Cuid;
            result.StartTimes = resultVM.StartTimes;
            result.EndTimes = resultVM.EndTimes;

            _context.Results.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}
