// Models/Service.cs

namespace Tiger_Tasks.Models
{
public class Service
{
    public int ServiceId { get; set; } // Primary key
    public string? UserId { get; set; } // Foreign key linking to ApplicationUser
    public string? ServiceName { get; set; } // Service description
    public bool IsOffered { get; set; } // true = provided, false = needed

    
    // Optional navigation property
    public ApplicationUser? User { get; set; }

    public string? ProviderUserId { get; set; }

    public ApplicationUser? ProviderUser { get; set; }
}
}