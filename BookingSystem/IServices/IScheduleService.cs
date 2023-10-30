using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IScheduleService
    {
        public Task<booking> Booking(booking booking);

        public Task<booking> CancelBooking(booking booking);
    }
}
