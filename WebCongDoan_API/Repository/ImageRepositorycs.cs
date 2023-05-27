using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ImageRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddImage(ImageVM imgVM)
        {
            var img = _mapper.Map<Image>(imgVM);
            _context.Images.Add(img);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int id)
        {
            var img = _context.Images.SingleOrDefault(p => p.ImgId == id);
            _context.Images.Remove(img);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ImageVM>> GetAllImage()
        {
            var prizes = await _context.Images.ToListAsync();
            return _mapper.Map<List<ImageVM>>(prizes);
        }

        public async Task<ImageVM> GetImageById(int id)
        {
            var img = await _context.Images.FindAsync(id);
            return _mapper.Map<ImageVM>(img);
        }

        public async Task UpdateImage(ImageVM imgVM)
        {
            var img = _mapper.Map<Image>(imgVM);
            _context.Images.Update(img);
            await _context.SaveChangesAsync();
        }
    }
}
