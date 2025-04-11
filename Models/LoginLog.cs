using System;
using System.ComponentModel.DataAnnotations;

namespace SteelHorseTrucks.Models
{
    public class LoginLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool IsSuccess { get; set; }

        [Required]
        public DateTime AttemptTime { get; set; }

        public string? IPAddress { get; set; }

        public string? Reason { get; set; }
    }
}
