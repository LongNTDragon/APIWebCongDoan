using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddRole(RoleVM roleVM)
        {
            var newRole = _mapper.Map<Role>(roleVM);
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
            var deleteRole = _context.Roles.SingleOrDefault(r => r.RoleId == id);
            _context.Roles.Remove(deleteRole);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoleVM>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<List<RoleVM>>(roles);
        }

        public async Task<RoleVM> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return _mapper.Map<RoleVM>(role);
        }

        public async Task UpdateRole(RoleVM roleVM)
        {
            var updateRole = _mapper.Map<Role>(roleVM);
            _context.Roles.Update(updateRole);
            await _context.SaveChangesAsync();
        }
    }
}
