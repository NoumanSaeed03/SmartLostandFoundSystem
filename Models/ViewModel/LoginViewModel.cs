using System.ComponentModel.DataAnnotations;

namespace SmartLostandFoundSystem.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)] //hidden kry ga
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
