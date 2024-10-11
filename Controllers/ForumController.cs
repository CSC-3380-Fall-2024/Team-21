using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tiger_Tasks.Data;
using Tiger_Tasks.Models;
using Microsoft.EntityFrameworkCore;

namespace Tiger_Tasks.Controllers
{
    //Controller allows the creation of a forum and manges the syncs to the database
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _context.ForumPosts.Include(posts => p.User).ToListAsync();
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ForumPost post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;
                post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
    }
}
