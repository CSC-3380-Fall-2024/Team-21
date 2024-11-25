using Microsoft.AspNetCore.Identity;

namespace Tiger_Tasks.Models
{
    public class ApplicationUser: IdentityUser
    {   

        public virtual ProfileModel Profile { get; set; }

        public virtual ICollection<Service> NeededServices { get; set; } = new List<Service>(); // Services the user needs
        public virtual ICollection<Service> ProvidedServices { get; set; } = new List<Service>(); // Services the user provides
        /*  public string Email { get; set; }
          public string Password { get; set; }

          public string ConfirmPassword { get; set; }

          public string? FirstName { get; set; }
          public string? LastName { get; set; }

          public string? Bio   { get; set; }
          public string? Major { get; set; }

          public string? Minor { get; set; }

          public string? Extracurriculars { get; set; }
          public virtual ICollection<Service> NeededServices { get; set; } = new List<Service>();
          public virtual ICollection<Service> ProvidedServices { get; set; } = new List<Service>();
         */
    }
}
