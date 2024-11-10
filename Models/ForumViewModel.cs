namespace Tiger_Tasks.Models
{
    public class ForumViewModel
    {
            public string SelectedPostType { get; set; } // The selected post type (Help Wanted or Help Needed)
            public string SelectedServiceType { get; set; } // The selected service category
            public List<ForumPost> ForumPosts { get; set; } // The list of forum posts
            public List<string> ServiceCategories { get; set; } = ForumPost.ServiceCategories; // Service categories for dropdown
            public List<string> PostTypes { get; set; } = ForumPost.PostTypes; // Post types for dropdown
  
    }
}
