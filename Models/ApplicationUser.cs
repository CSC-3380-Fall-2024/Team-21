using Microsoft.AspNetCore.Identity;

namespace Tiger_Tasks.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Major { get; set; }

    }
}
