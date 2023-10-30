using BookingSystem.IServices;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BookingSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly AppDbContext _context;


        public ScheduleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<booking> Booking(booking booking)
        {
            user_package credits = await _context.user_package.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            int available_credits = credits.available_credits;

            ClassSchedule result = await _context.classSchedule.AsNoTracking().FirstOrDefaultAsync(x => x.classid == booking.classid);
            int credit = result.no_of_credits;
            if (available_credits >= credit)
            {

                user_package user_Package = await _context.user_package.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
                user_Package.used_credits = credit;
                user_Package.available_credits = available_credits - credit;
                _context.user_package.Update(user_Package);
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
                await _context.booking.AddAsync(booking);
                await _context.SaveChangesAsync();
                return booking;

            }
            else
            {
                return null;
            }
        }
        public async Task<booking> CancelBooking(booking booking)
        {
            user_package credits = await _context.user_package.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            int available_credits = credits.available_credits;

            ClassSchedule result = await _context.classSchedule.AsNoTracking().FirstOrDefaultAsync(x => x.classid == booking.classid);
            int credit = result.no_of_credits;

            user_package user_Package = await _context.user_package.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            user_Package.used_credits = user_Package.used_credits - credit;
            user_Package.available_credits = available_credits + credit;
            _context.user_package.Update(user_Package);
            await _context.SaveChangesAsync();

            booking booking1 = await _context.booking.AsNoTracking().FirstOrDefaultAsync(x => x.user_pid == booking.user_pid);
            booking1.status = "Cancel";
            _context.booking.Update(booking1);
            await _context.SaveChangesAsync();
            return booking;

        }

    }
}
