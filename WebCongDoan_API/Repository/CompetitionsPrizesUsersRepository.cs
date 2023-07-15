using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionsPrizesUsersRepository : ICompetitionsPrizesUsersRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionsPrizesUsersRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCompetitionsPrizesUsers(CompetitionsPrizesUsersVM comPUVM)
        {
            var comPU = new CompetitionsPrizesUsers();
            comPU.Cpid = comPUVM.Cpid;
            comPU.UserId = comPUVM.UserId;

            _context.CompetitionsPrizesUsers.Add(comPU);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompetitionsPrizesUsers(int id)
        {
            var comPU = _context.CompetitionsPrizesUsers.FirstOrDefault(c => c.Id == id);
            _context.CompetitionsPrizesUsers.Remove(comPU);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionsPrizesUsersVM>> GetAllCompetitionsPrizesUsers()
        {
            var comPUs = await _context.CompetitionsPrizesUsers.ToListAsync();
            return _mapper.Map<List<CompetitionsPrizesUsersVM>>(comPUs);
        }

        public async Task<List<CompetitionsPrizesUsersVM>> GetAllCompetitionsPrizesUsersByCPID(int id)
        {
            var comPUs = await _context.CompetitionsPrizesUsers.Where(c => c.Cpid == id).ToListAsync();
            return _mapper.Map<List<CompetitionsPrizesUsersVM>>(comPUs);
        }

        public async Task<CompetitionsPrizesUsersVM> GetCompetitionsPrizesUsersByID(int id)
        {
            var comPU = await _context.CompetitionsPrizesUsers.SingleOrDefaultAsync(q => q.Id == id);
            return _mapper.Map<CompetitionsPrizesUsersVM>(comPU);
        }

        public async Task UpdateCompetitionsPrizesUsers(CompetitionsPrizesUsersVM comPUVM)
        {
            var comPU = _context.CompetitionsPrizesUsers.SingleOrDefault(c => c.Id == comPUVM.Id);
            comPU.Cpid = comPUVM.Cpid;
            comPU.UserId = comPUVM.UserId;

            _context.CompetitionsPrizesUsers.Update(comPU);
            await _context.SaveChangesAsync();
        }
    }
}
