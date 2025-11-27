using BookingSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public class UserInfoDTO
    {
        public enum Country
        {
            //SelectCountry = 0,
            Myanmar = 1,
            Singapore = 2
        }
        [Key]
        public int userid { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phno { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid country must be selected.")]
        public Country countryid { get; set; }
        [DataType(DataType.Password)] 
        [MinLength(8)]
        [Required]
        public String password { get; set; }


    }
}
