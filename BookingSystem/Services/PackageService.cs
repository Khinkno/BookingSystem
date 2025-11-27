using BookingSystem.IServices;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Services
{
    public class PackageService : IPackageService
    {
        private readonly AppDbContext _context;


        public PackageService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Packages>> GetPackages(int countryid)
        {
            if (countryid != 0)
            {
                return await _context.packages.AsNoTracking().Where(x => x.countryid == countryid && x.expired_date >= DateTime.Now).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<UserPackage> BuyPackages(UserPackage user_package)
        {
            if (AddPaymentCard(user_package.payment))
            {
                var data = await _context.UserPackage.FirstOrDefaultAsync();
               
                await _context.UserPackage.AddAsync(user_package);
                await _context.SaveChangesAsync();

            }
            return user_package;
        }

        public async Task<Packages> GetCreditsByCountryid(int countryid, int pid)
        {
            Packages result = await _context.packages.AsNoTracking().FirstOrDefaultAsync(x => x.countryid == countryid && x.pid == pid);
            return result;
        }

        public async Task<List<UserPackage>> GetPurchasedPackages(int userid)
        {
            if (userid != 0)
            {
                return await _context.UserPackage.AsNoTracking().Where(x => x.userid == userid).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public bool AddPaymentCard(string payment)
        {
            return true;
        }



        public bool PaymentCharge(string payment)
        {
            return true;
        }

    }
}
