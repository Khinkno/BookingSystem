using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IPackageService
    {
        public Task<List<Packages>> GetPackages(int countryid);

        public Task<Packages> GetCreditsByCountryid(int countryid, int pid);

        public Task<UserPackage> BuyPackages(UserPackage user_Package);

        public Task<List<UserPackage>> GetPurchasedPackages(int userid);


    }
}
