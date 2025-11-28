using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public record UserInfoDTO
    {
        public enum Country
        {
            Myanmar = 1,
            Singapore = 2
        }

        public int userid { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phno { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid country must be selected.")]
        public Country countryid { get; set; } // Use int for easy mapping

        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public string password { get; set; }
    }
}
