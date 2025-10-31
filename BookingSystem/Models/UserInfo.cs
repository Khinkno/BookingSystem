using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
   
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
        public int countryid { get; set; }
      
        [DataType(DataType.Password)] // <-- ADD THIS ATTRIBUTE
        [MinLength(8)]
        [Required]
        public String password { get; set; }

      
    }
}
