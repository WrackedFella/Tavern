using System.ComponentModel.DataAnnotations;

namespace Tavern.Ui.Auth.Models
{
    public class AuthModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
