using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface ICompetitionsBlogsUserRepository
    {
        public Task<List<CompetitionsBlogsUserVM>> GetAllComBlogUsers();

        public Task<CompetitionsBlogsUserVM> GetComBlogUserById(int id);

        public Task AddComBlogUser(CompetitionsBlogsUserVM cbuVM);

        public Task UpdateComBlogUser(CompetitionsBlogsUserVM cbuVM);

        public Task DeleteComBlogUser(int id);
    }
}
