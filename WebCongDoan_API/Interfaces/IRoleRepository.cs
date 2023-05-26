using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<RoleVM>> GetAllRoles();

        public Task<RoleVM> GetRoleById(int id);

        public Task AddRole(RoleVM roleVM);

        public Task UpdateRole(RoleVM roleVM);

        public Task DeleteRole(int id);
    }
}
