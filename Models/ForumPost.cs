using Microsoft.Identity.Client;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tiger_Tasks.Models
{
    //This is the model resposible for all of the forum variables
    public class ForumPost
    {
        public int Id { get; set; }

        [Required] 
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string PostType { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public DateTime Created { get; set; }

        // Static list of available service categories for the dropdown
        public static List<string> ServiceCategories => new List<string>
    {
        "Tutoring",
        "IT Help",
        "Manual Labor",
        "Coding Help"
    };

        // Static list of post types for dropdown (Help Wanted or Help Needed)
        public static List<string> PostTypes => new List<string>
    {
        "Help Wanted",
        "Help Needed"
    };

        public string SelectedPostType { get; set; }
        public string SelectedServiceType { get; set; }

    }

 
}
