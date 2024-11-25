using System.ComponentModel.DataAnnotations.Schema;

namespace Tiger_Tasks.Models
{
    public class ProfileModel
    {
       
        public string Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? UserName { get; set; }
        public string? Bio { get; set; }
        public string? Major { get; set; }

        public string? Minor { get; set; }

        public string? Extracurriculars { get; set; }
        public virtual ICollection<Service> NeededServices { get; set; } = new List<Service>();
        public virtual ICollection<Service> ProvidedServices { get; set; } = new List<Service>();
    }
}
