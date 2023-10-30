using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class ClassSchedule
    {
        [ConcurrencyCheck]
        [Key]
        public int classid { get; set; }

        public string name { get; set; }

        public int countryid { get; set; }

        public int no_of_credits { get; set; }

        public int available_slots { get; set; }

        public int waitlist_slots { get; set; }


        public DateTime start_datetime { get; set; }

        public DateTime end_datetime { get; set; }

        public int duration { get; set; }


    }
}
