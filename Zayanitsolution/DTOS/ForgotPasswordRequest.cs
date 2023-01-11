using System.ComponentModel.DataAnnotations;

namespace Scorerecord.DTOS
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
