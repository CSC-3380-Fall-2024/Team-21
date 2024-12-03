namespace Tiger_Tasks.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PostType PostType { get; set; }
        public ForumPost() 
        {

        }
    }
    public enum PostType
    {
        HelpWanted,
        HelpOffered
    }

}
