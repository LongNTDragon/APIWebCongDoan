using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserVM>> GetAllUsers();

        public Task<List<UserVM>> GetAllUsersByRoleID(int id);

        public Task<List<UserVM>> GetAllUsersByDepID(int id);

        public Task<UserVM> GetUserById(string id);

        public Task AddUser(RegisterVM registerVM);

        public Task UpdateUser(UserVM userVM);

        public Task DeleteUser(string id);

        public Task<string> GetUserByEmailAndPass(LoginVM loginVM);

        public Task UpdateIsDeletedByUserID(string id, int value);
    }
}
