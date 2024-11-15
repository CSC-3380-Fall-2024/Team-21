using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tiger_Tasks.Data;
using Tiger_Tasks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Tiger_Tasks.Controllers
{
    // Controller allows the creation of a forum and manages synchronization with the database
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string postType , string serviceType)
        {
            // Start with all forum posts from the database
            var filteredPosts = _context.ForumPost.AsQueryable();

            // Apply filters based on post type and service type
            if (!string.IsNullOrEmpty(postType))
            {
                filteredPosts = filteredPosts.Where(p => p.PostType == postType);
            }

            if (!string.IsNullOrEmpty(serviceType))
            {
                filteredPosts = filteredPosts.Where(p => p.ServiceType == serviceType);
            }

            // Populate the ForumViewModel with filtered posts and other necessary data
            var model = new ForumViewModel
            {
                ServiceCategories = new List<string> { "Tutoring", "IT Help", "Manual Labor", "Coding Help" },
               // PostTypes = new List<string> { "Help Wanted", "Help Needed"},
                SelectedServiceType = serviceType,
                SelectedPostType = postType,
                ForumPosts = filteredPosts.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ForumViewModel
            {
                ServiceCategories = ForumPost.ServiceCategories,
                PostTypes = ForumPost.PostTypes
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(ForumPost post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;
                _context.ForumPost.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Provide the list of categories and post types if there's an error or page reload
            var model = new ForumViewModel
            {
                ServiceCategories = ForumPost.ServiceCategories,
                PostTypes = ForumPost.PostTypes,
                SelectedServiceType = post.ServiceType,
                SelectedPostType = post.PostType,
                ForumPosts = _context.ForumPost.ToList()
            };

            return View(model);
        }
    }
}