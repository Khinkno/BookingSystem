using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class booking
    {
        [ConcurrencyCheck]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookingid { get; set; }

        public int user_pid { get; set; }

        public int classid { get; set; }

        public int userid { get; set; }

        public string status { get; set; }


        public DateTime created_date { get; set; }
    }
}
