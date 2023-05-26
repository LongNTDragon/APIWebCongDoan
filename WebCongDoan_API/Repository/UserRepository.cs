using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MyDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddUser(RegisterVM registerVM)
        {
            var newUser = _mapper.Map<User>(registerVM);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
        {
            var deleteUser = _context.Users.SingleOrDefault(u => u.UserId == id);
            _context.Users.Remove(deleteUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserVM>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<LoginVM> GetUserByEmailAndPass(LoginVM loginVM)
        {
            var user = _context.Users.SingleOrDefault(u=>u.Email == loginVM.Email && u.Password == loginVM.Password);
            return _mapper.Map<LoginVM>(user);
        }

        public async Task<UserVM> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task UpdateUser(UserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


    }
}
