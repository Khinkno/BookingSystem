using BookingSystem.Models;

namespace BookingSystem.IServices
{
    public interface IScheduleService
    {
        public Task<string> CreateBooking(booking booking);

        public Task<List<ClassSchedule>> GetclassSchedule(int countryid);
        public Task<string> CancelBooking(booking booking);

    }
}
