// Controllers/ServiceController.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tiger_Tasks.Models;


namespace Tiger_Tasks.Data
{

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/service/{userId}
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetServices(string userId)
    {
        var neededServices = await _context.Services
            .Where(s => s.UserId == userId && !s.IsOffered)
            .Select(s => s.ServiceName)
            .ToListAsync();

        var providedServices = await _context.Services
            .Where(s => s.UserId == userId && s.IsOffered)
            .Select(s => s.ServiceName)
            .ToListAsync();

        return Ok(new
        {
            NeededServices = neededServices,
            ProvidedServices = providedServices
        });
    }

    // POST: api/service/add
    [HttpPost("add")]
    public async Task<IActionResult> AddService([FromBody] Service newService)
    {
        if (newService == null || string.IsNullOrWhiteSpace(newService.ServiceName))
        {
            return BadRequest(new { message = "Service name is required." });
        }

        _context.Services.Add(newService);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Service added successfully" });
    }

    // DELETE: api/service/delete/{serviceId}
    [HttpDelete("delete/{serviceId}")]
    public async Task<IActionResult> DeleteService(int serviceId)
    {
        var service = await _context.Services.FindAsync(serviceId);
        if (service == null)
        {
            return NotFound(new { message = "Service not found" });
        }

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Service deleted successfully" });
        }
    }
}