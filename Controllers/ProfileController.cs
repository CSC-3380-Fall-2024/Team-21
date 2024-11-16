// Controllers/ProfileController.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tiger_Tasks.Models;



namespace Tiger_Tasks.Controllers
{

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: api/profile/{userId}
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProfile(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new
        {
            user.FirstName,
            user.LastName,
            user.UserName, // Username displayed under First and Last name
            user.Bio,
            user.Major,
            user.Minor,
            user.Extracurriculars // Include extracurriculars in response
        });
    }

    // POST: api/profile/{userId}/editBio
    [HttpPost("{userId}/editBio")]
    public async Task<IActionResult> UpdateBio(string userId, [FromForm] ApplicationUser bioUpdate)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        // Update bio, major, minor, and extracurriculars only
        user.Bio = bioUpdate.Bio;
        user.Major = bioUpdate.Major;
        user.Minor = bioUpdate.Minor;
        user.Extracurriculars = bioUpdate.Extracurriculars;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(new { message = "Failed to update profile bio" });
        }

        return Ok(new { message = "Profile bio updated successfully" });
    }
}
}