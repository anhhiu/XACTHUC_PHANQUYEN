using System.ComponentModel.DataAnnotations;

namespace BAI_1.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PassWord { get; set; }
    }
}
