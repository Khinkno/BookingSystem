using BookingSystem.IServices;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Cryptography;

namespace BookingSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly AppDbContext _context;

        private IDistributedCache _distributedCache;
        public ScheduleService(AppDbContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }
        public async Task<List<ClassSchedule>> GetclassSchedule(int countryid)
        {
            if (countryid != 0)
            {
                return await _context.classSchedule.AsNoTracking().Where(x => x.countryid == countryid).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<string> CreateBooking(booking booking)
        {

            UserPackage credits = await _context.UserPackage.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            int available_credits = credits.available_credits;

            ClassSchedule result = await _context.classSchedule.AsNoTracking().FirstOrDefaultAsync(x => x.classid == booking.classid);
            int credit = result.no_of_credits;


            if (available_credits >= credit)
            {

                int occupiedSlots = int.Parse(_distributedCache.GetString("OccupiedSlots" + result.classid) ?? "0");
                int occupiedWaitListSlots = int.Parse(_distributedCache.GetString("OccupiedWaitListSlots" + result.classid) ?? "0");
                if (result.available_slots > occupiedSlots)
                {
                    UserPackage userPackage = await _context.UserPackage.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid && x.isexpired == false);
                    userPackage.used_credits = credit;
                    userPackage.available_credits = available_credits - credit;
                    _context.UserPackage.Update(userPackage);
                    await _context.SaveChangesAsync();

                    var data = await _context.booking.FirstOrDefaultAsync();
                    if (data == null)
                    {
                        booking.bookingid = 1;
                    }
                    else
                    {
                        booking.bookingid = _context.booking.Max(x => x.user_pid) + 1;
                    }

                    _distributedCache.SetString("OccupiedSlots" + result.classid, occupiedSlots + 1 + "");
                    booking.status = "Booked";
                    await _context.booking.AddAsync(booking);
                    await _context.SaveChangesAsync();
                    return "Successful";

                }
                else if (result.waitlist_slots > occupiedWaitListSlots)
                {
                    UserPackage userPackage = await _context.UserPackage.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid && x.isexpired == false);
                    userPackage.used_credits = credit;
                    userPackage.available_credits = available_credits - credit;
                    _context.UserPackage.Update(userPackage);
                    await _context.SaveChangesAsync();

                    var data = await _context.booking.FirstOrDefaultAsync();
                    if (data == null)
                    {
                        booking.bookingid = 1;
                    }
                    else
                    {
                        booking.bookingid = _context.booking.Max(x => x.user_pid) + 1;
                    }

                    _distributedCache.SetString("OccupiedWaitListSlots" + result.classid, occupiedWaitListSlots + 1 + "");
                    booking.status = "WaitList";
                    await _context.booking.AddAsync(booking);
                    await _context.SaveChangesAsync();
                    return "Successful ";

                }
                else
                {
                    return "Failed";
                }

            }
            else
            {
                return "Failed";
            }
        }
        public async Task<string> CancelBooking(booking booking)
        {
            UserPackage credits = await _context.UserPackage.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            int available_credits = credits.available_credits;

            ClassSchedule result = await _context.classSchedule.AsNoTracking().FirstOrDefaultAsync(x => x.classid == booking.classid);
            int credit = result.no_of_credits;

            UserPackage user_Package = await _context.UserPackage.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            user_Package.used_credits = user_Package.used_credits - credit;
            user_Package.available_credits = available_credits + credit;
            _context.UserPackage.Update(user_Package);
            await _context.SaveChangesAsync();

            booking cancelbooking = await _context.booking.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            cancelbooking.status = "Cancel";
            _context.booking.Update(cancelbooking);
            await _context.SaveChangesAsync();

            booking waitlistbooking = await _context.booking.AsNoTracking().FirstOrDefaultAsync(x => x.status == "WaitList");
            waitlistbooking.status = "Booked";
            _context.booking.Update(waitlistbooking);
            await _context.SaveChangesAsync();
            return "Successful";

        }

    }
}
