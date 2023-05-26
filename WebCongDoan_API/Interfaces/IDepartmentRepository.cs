using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<List<DepartmentVM>> GetAllDepartments();

        public Task<DepartmentVM> GetDepartmentById(int id);

        public Task AddDepartment(DepartmentVM depVM);

        public Task UpdateDepartment(DepartmentVM depVM);

        public Task DeleteDepartment(int id);
    }
}
