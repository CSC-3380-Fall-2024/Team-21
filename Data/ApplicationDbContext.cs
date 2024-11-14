using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tiger_Tasks.Models;

namespace Tiger_Tasks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        [Required] public DbSet<ForumPost> ForumPost { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        


    }
}
