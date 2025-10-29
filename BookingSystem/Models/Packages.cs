using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class Packages
    {
        [ConcurrencyCheck]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pid { get; set; }

        public string name { get; set; }

        public int countryid { get; set; }

        public int no_of_credits { get; set; }

        public double price { get; set; }

        public DateTime start_date { get; set; }

        public DateTime expired_date { get; set; }

        public int duration { get; set; }


    }
}
