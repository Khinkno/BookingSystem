using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class user_package
    {
        [ConcurrencyCheck]
        [Key]
        public int user_pid { get; set; }

        public int userid { get; set; }

        public int pid { get; set; }

        public DateTime datetime { get; set; }

        public bool isexpired { get; set; }

        public string payment { get; set; }

        public int available_credits { get; set; }

        public int used_credits { get; set; }


    }
}
