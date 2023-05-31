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
        private IConfiguration _configuration;

        public UserRepository(MyDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task AddUser(RegisterVM registerVM)
        {
            var newUser = new User();
            newUser.UserId = registerVM.UserId;
            newUser.UserName = registerVM.UserName;
            newUser.DateOfBirth = registerVM.DateOfBirth;
            newUser.Email = registerVM.Email;
            newUser.Password = registerVM.Password;
            newUser.DepId = registerVM.DepId;
            newUser.RoleId = registerVM.RoleId;

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

        public async Task<List<UserVM>> GetAllUsersByDepID(int id)
        {
            var users = await _context.Users.Where(u => u.DepId == id).ToListAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<List<UserVM>> GetAllUsersByRoleID(int id)
        {
            var users = await _context.Users.Where(u => u.RoleId == id).ToListAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<string> GetUserByEmailAndPass(LoginVM loginVM)
        {

            /// logic   
            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.Email == loginVM.Email && u.Password == loginVM.Password);
            if (user == null) throw new Exception("email hoac password khong chinh xac");






            // set roles 
            IList<string>? userRoles = new List<string>() { user.Role.RoleName };





            var token = TokenHelper.GenerateToken(
           _configuration["JWT:Secret"]
           , _configuration["JWT:ValidIssuer"]
           , _configuration["JWT:ValidAudience"]
           , userRoles
           , user.UserId
           , user.UserName ?? ""
           , user.UserAddress ?? "");


            return token;
        }

        public async Task<UserVM> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task UpdateUser(UserVM userVM)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == userVM.UserId);
            user.UserId = userVM.UserId;
            user.UserName = userVM.UserName;
            user.DateOfBirth = userVM.DateOfBirth;
            user.Email = userVM.Email;
            user.Password = userVM.Password;
            user.DepId = userVM.DepId;
            user.RoleId = userVM.RoleId;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
