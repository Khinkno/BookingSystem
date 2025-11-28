using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTO
{
    public record UserPackageDTO
    {
        public int UserPackageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PackageId { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsExpired { get; set; }

        public string Payment { get; set; }

        public int AvailableCredits { get; set; }

        public int UsedCredits { get; set; }
    }
}
