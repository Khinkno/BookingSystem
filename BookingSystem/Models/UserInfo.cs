using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public enum Country
    {
        Myanmar =1,
        Singapore=2
    }
    public class UserInfo
    {
        [ConcurrencyCheck]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }
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
