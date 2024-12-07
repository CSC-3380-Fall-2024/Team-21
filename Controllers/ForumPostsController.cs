using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Tiger_Tasks.Data;
using Tiger_Tasks.Models;

namespace Tiger_Tasks.Controllers
{
    public class ForumPostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ForumPostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index(PostType? postTypeFilter, ServiceType? serviceTypeFilter,  decimal? maxCost)
        {
            // Pass the filter options to the view
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));
            ViewData["ServiceType"] = new SelectList(Enum.GetValues(typeof(ServiceType)));

           

            var posts = _context.ForumPost.AsQueryable();
            //Logic for filtering post in the index view 

            if (postTypeFilter.HasValue)
            {
                posts = posts.Where(p => p.PostType == postTypeFilter);
            }

            if (serviceTypeFilter.HasValue)
            {
                posts = posts.Where(p => p.ServiceType == serviceTypeFilter);
            }

       
            // Filter by Maximum Cost
            if (maxCost.HasValue)
            {
                posts = posts.Where(p => p.Cost <= maxCost.Value);
            }


            return View(await posts.ToListAsync());
        }

        // GET forurm post details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // GET forumPost creation
        public IActionResult Create()
        {
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));
            ViewData["ServiceType"] = new SelectList(Enum.GetValues(typeof(ServiceType)));
            return View();
        }

        // POST: ForumPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PostType,ServiceType,Cost")] ForumPost forumPost)
        {
            if (ModelState.IsValid)
            {
                // Set the UserId to the logged-in user's ID
                var user = await _userManager.GetUserAsync(User);

                //Assign userId when post is created
                forumPost.UserId = user.Id;

                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));
            ViewData["ServiceType"] = new SelectList(Enum.GetValues(typeof(ServiceType)));
            return View(forumPost);
        }

        // GET: ForumPosts/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));
            ViewData["ServiceType"] = new SelectList(Enum.GetValues(typeof(ServiceType)));
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PostType,ServiceType,Cost")] ForumPost forumPost)
        {
            //Throws and error if the forum post Id value was not found
            if (id != forumPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumPost);     // Updates the forum post if its valid
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumPostExists(forumPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
           
            // Repopulate dropdown if ModelState is invalid
            ViewData["PostTypes"] = new SelectList(new[]
            {
                 new { Value = "HelpWanted", Text = "Help Wanted" },
                 new { Value = "HelpNeeded", Text = "Help Needed" }
           }, "Value", "Text");
           
            ViewData["ServiceTypes"] = new SelectList(new[]
        {
                 new { Value = "ITHelp", Text = "IT Help" },
                 new { Value = "ManualLabor", Text = "Manual Labor" },
                 new { Value = "Tutoring", Text = "Tutoring" },
                 new { Value = "StudyGroup", Text = "Study Group" }
           }, "Value", "Text");

            return View(forumPost);
        }

        // GET: ForumPosts/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }
        public async Task<IActionResult> MyPosts()
        {
            // Get the logged-in user's ID from the User context
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Or use User.Identity.Name for username

            // Fetch all posts created by the logged-in user
            var userPosts = await _context.ForumPost
                                          .Where(p => p.UserId == userId)
                                          .ToListAsync();

            return View(userPosts);
        }
        // POST: ForumPosts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost != null)
            {
                _context.ForumPost.Remove(forumPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumPostExists(int id)
        {
            return _context.ForumPost.Any(e => e.Id == id);
        }
    }
}
