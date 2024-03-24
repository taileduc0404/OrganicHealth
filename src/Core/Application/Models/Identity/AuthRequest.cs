using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity
{
    public class AuthRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
