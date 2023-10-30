using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public class packagesDTO
    {
      
        [Key]
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
