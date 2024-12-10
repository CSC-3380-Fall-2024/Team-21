namespace Tiger_Tasks.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PostType PostType { get; set; }
        public ServiceType ServiceType { get; set; }

        public decimal Cost { get; set; } // Add Cost property
        public string? UserId { get; set; }  // Store the user ID here
        public ApplicationUser User { get; set; }  // This is for navigation to the user 
    
    public ForumPost() 
        {

        }
    }
    public enum PostType
    {
        HelpWanted,
        HelpOffered
    }

    public enum ServiceType
    {
        ITHelp,
        ManualLabor,
        Tutoring,
        StudyGroup
    }
   

}
