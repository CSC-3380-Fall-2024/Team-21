using Microsoft.AspNetCore.Identity;

namespace Tiger_Tasks.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Bio { get; set; }
        public string? ServicesNeeded { get; set; }
        public string? ServicesProvided { get; set; }
        public virtual ProfileModel Profile { get; set; }

        public virtual ICollection<Service> NeededServices { get; set; } = new List<Service>(); // Services the user needs
        public virtual ICollection<Service> ProvidedServices { get; set; } = new List<Service>(); // Services the user provides
    
    }
}
