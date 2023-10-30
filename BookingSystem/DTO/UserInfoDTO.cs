using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public class UserInfoDTO
    {
        [Key]
        public int userid { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string phno { get; set; }

        public int countryid { get; set; }

        public String password { get; set; }


    }
}
