using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddDepartment(DepartmentVM depVM)
        {
            var newDep = _mapper.Map<Department>(depVM);
            _context.Departments.Add(newDep);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            var deleteDep = _context.Departments.SingleOrDefault(d => d.DepId == id);
            _context.Departments.Remove(deleteDep);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DepartmentVM>> GetAllDepartments()
        {
            var deps = await _context.Departments.ToListAsync();
            return _mapper.Map<List<DepartmentVM>>(deps);
        }

        public async Task<DepartmentVM> GetDepartmentById(int id)
        {
            var dep = await _context.Departments.FindAsync(id);
            return _mapper.Map<DepartmentVM>(dep);
        }

        public async Task UpdateDepartment(DepartmentVM depVM)
        {
            var dep = _mapper.Map<Department>(depVM);
            _context.Departments.Update(dep);
            await _context.SaveChangesAsync();
        }
    }
}
