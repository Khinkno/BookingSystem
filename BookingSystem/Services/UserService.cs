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
                await _context.user.AddAsync(user);
                await _context.SaveChangesAsync();

            }
            return user;
        }

        public bool SendVerifyEmail(string email)
        {
            return true;
        }

        public async Task<UserInfo> GetUserLogin(string email, string password)
        {
            UserInfo result = await _context.user.AsNoTracking().FirstOrDefaultAsync(x => x.email == email && x.password == password);
            return result;
        }

        public async Task<List<UserInfo>> GetProfile(int userid)
        {
            return await _context.user.AsNoTracking().Where(x => x.userid == userid).ToListAsync();

        }
        public async Task<string> ResetPassword(string email, string oldpassword, string newpassword)
        {
            UserInfo user = await _context.user.AsNoTracking().FirstOrDefaultAsync(x => x.email == email && x.password == oldpassword);
            if (user != null)
            {
                user.password = newpassword;
                _context.user.Update(user);
                await _context.SaveChangesAsync();
                return "Successful";
            }
            else
                return "Wrong Password or Email";
        }

        public async Task<int> GetCountryIdByUserid(int userid)
        {
            UserInfo user = await _context.user.AsNoTracking().FirstOrDefaultAsync(x => x.userid == userid);

            return user.countryid;

        }

    }
}
