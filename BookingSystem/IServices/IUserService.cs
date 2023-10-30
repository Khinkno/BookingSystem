using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IUserService
    {
       
        public Task<UserInfo> RegisterUser(UserInfo user);

        public Task<UserInfo> GetUserLogin(string email,string password);

    }
}