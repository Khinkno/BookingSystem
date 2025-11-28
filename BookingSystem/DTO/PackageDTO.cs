using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public record PackageDTO
    {
        public int Pid { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NoOfCredits { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
