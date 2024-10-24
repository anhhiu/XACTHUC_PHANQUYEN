using System.ComponentModel.DataAnnotations;

namespace BAI_1.Models
{
    public class SignnUpModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PassWord { get; set; }

        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
