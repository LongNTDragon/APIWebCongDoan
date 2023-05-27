using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ITagRepository
    {
        public Task AddTag(TagVM tagVM);


        public Task DeleteTag(int id);


        public Task<List<TagVM>> GetAllTags();


        public Task<TagVM> GetTagById(int id);


        public Task UpdateTag(TagVM tagVM);
        
    }
}
