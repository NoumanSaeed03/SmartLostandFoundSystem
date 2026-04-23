using System.ComponentModel.DataAnnotations;

namespace SmartLostandFoundSystem.Models.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        //emailaddress basically automatically validate kry ga email ko
        public string Email { get; set; }
        [Required, DataType(DataType.Password)] //hidden kry ga
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        //public string role {  get; set; }
    }
}
