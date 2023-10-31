using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IUserService
    {
       
        public Task<UserInfo> RegisterUser(UserInfo user);

        public Task<UserInfo> GetUserLogin(string email,string password);

        public Task<List<UserInfo>> GetProfile(int userid);

        public Task<string> ResetPassword(int userid,string oldpassword,string newpassword);

    }
}