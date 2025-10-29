using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public class UserInfoDTO
    {
        [Key]
        //public int userid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phno { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid country must be selected.")]
        public int countryid { get; set; }
        [Required]
        public String password { get; set; }


    }
}
