using Microsoft.Identity.Client;

namespace Tiger_Tasks.Models
{
    //This is the model resposible for all of the forum variables
    public class ForumPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Created{get; set;}
        public string? UserId {  get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
