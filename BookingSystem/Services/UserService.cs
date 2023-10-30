using BookingSystem.IServices;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;


        public UserService(AppDbContext context)
        {
            _context = context;
        }

     
        public async Task<UserInfo> RegisterUser(UserInfo user)
        {
            if (SendVerifyEmail(user.email))
            {
                var data = await _context.user.FirstOrDefaultAsync();
                if (data == null)
                {
                    user.userid = 1;
                }
                else
                {
                    user.userid = _context.user.Max(x => x.userid) + 1;
                }
                await _context.user.AddAsync(user);
                await _context.SaveChangesAsync();
                
            }
            return user;
        }

        public bool SendVerifyEmail(string email)
        {
            return true;
        }

        public async Task<UserInfo> GetUserLogin(string email,string password)
        {
            UserInfo result = await _context.user.AsNoTracking().FirstOrDefaultAsync(predicate: x => x.email == email && x.password==password);
            return result;
        }
    }
}
