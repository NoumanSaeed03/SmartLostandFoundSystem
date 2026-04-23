using Microsoft.AspNetCore.Identity;

namespace SmartLostandFoundSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? LastActivityTime { get; set; }
    }
}