﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class CompetitionsPrizeRepositoty : ICompetitionsPrizeRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CompetitionsPrizeRepositoty(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCompetitionsPrize(CompetitionsPrizeVM comPVM)
        {
            var comPri = new CompetitionsPrize();
            comPri.PriId = comPVM.PriId;
            comPri.PriTid = comPVM.PriTid;
            comPri.ComId = comPVM.ComId;
            comPri.Quantity = comPVM.Quantity;
            comPri.PrizeDetail = comPVM.PrizeDetail;

            _context.CompetitionsPrizes.Add(comPri);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompetitionsPrize(int id)
        {
            var comPri = _context.CompetitionsPrizes.SingleOrDefault(cp => cp.Cpid == id);
            _context.CompetitionsPrizes.Remove(comPri);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionsPrizeVM>> GetAllCompetitionsPrizes()
        {
            var comPris = await _context.CompetitionsPrizes.ToListAsync();
            return _mapper.Map<List<CompetitionsPrizeVM>>(comPris);
        }

        public async Task<List<CompetitionsPrizeVM>> GetAllCompetitionsPrizesByComID(int id)
        {
            var comPris = await _context.CompetitionsPrizes.Where(cp => cp.ComId == id).ToListAsync();
            return _mapper.Map<List<CompetitionsPrizeVM>>(comPris);
        }

        public async Task<CompetitionsPrizeVM> GetCompetitionsPrizeById(int id)
        {
            var comPri = await _context.CompetitionsPrizes.FindAsync(id);
            return _mapper.Map<CompetitionsPrizeVM>(comPri);
        }

        public async Task UpdateCompetitionsPrize(CompetitionsPrizeVM comPVM)
        {
            var comPri = _context.CompetitionsPrizes.SingleOrDefault(c => c.Cpid == comPVM.Cpid);
            comPri.PriId = comPVM.PriId;
            comPri.PriTid = comPVM.PriTid;
            comPri.ComId = comPVM.ComId;
            comPri.Quantity = comPVM.Quantity;
            comPri.PrizeDetail = comPVM.PrizeDetail;

            _context.CompetitionsPrizes.Update(comPri);
            await _context.SaveChangesAsync();
        }
    }
}
