using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public class BookingDTO
    {

        [Key]
        public int bookingid { get; set; }

        public int user_pid { get; set; }

        public int classid { get; set; }

        public int userid { get; set; }

        public string status { get; set; }


        public DateTime created_date { get; set; }


    }
}
