using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IUserService
    {
       
        public Task<UserInfo> RegisterUser(UserInfo user);

        public Task<UserInfo> GetUserLogin(string email,string password);

        public Task<List<UserInfo>> GetProfile(int userid);

        public Task<string> ResetPassword(string email,string oldpassword,string newpassword);

        public Task<int> GetCountryIdByUserid(int userid);

    }
}