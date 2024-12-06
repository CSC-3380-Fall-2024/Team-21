using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tiger_Tasks.Data;
using Tiger_Tasks.Models;

namespace Tiger_Tasks.Controllers
{
    public class ForumPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index(PostType? filter)
        {
            // Pass the filter options to the view
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));

            var posts = _context.ForumPost.AsQueryable();
            //Logic for filtering post in the index view
            if (filter.HasValue)
            {
                posts = posts.Where(p => p.PostType == filter);
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
            return View();
        }

        // POST: ForumPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PostType")] ForumPost forumPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostTypes"] = new SelectList(Enum.GetValues(typeof(PostType)));
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
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PostType")] ForumPost forumPost)
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
