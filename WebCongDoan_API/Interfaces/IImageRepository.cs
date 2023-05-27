using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IImageRepository
    {
        public Task AddImage(ImageVM imgVM);

        public Task DeleteImage(int id);

        public Task<List<ImageVM>> GetAllImage();


        public Task<ImageVM> GetImageById(int id);


        public Task UpdateImage(ImageVM imgVM);
        
    }
}
