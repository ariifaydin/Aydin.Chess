using System.ComponentModel.DataAnnotations;

namespace Web.UI.Models
{
    public class LoginModel
    {

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
