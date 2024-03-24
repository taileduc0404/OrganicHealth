using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3)]
        public string? Username { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}
