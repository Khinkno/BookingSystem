using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IPackageService
    {
        public Task<List<Packages>> GetPackages(int countryid);

        public Task<Packages> GetCreditsByCountryid(int countryid, int pid);

        public Task<user_package> BuyPackages(user_package user_Package);

        public Task<List<user_package>> GetPurchasedPackages(int userid);


    }
}
