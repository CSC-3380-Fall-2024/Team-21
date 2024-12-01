using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tiger_Tasks.Models;

namespace Tiger_Tasks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
      
        public DbSet<Service> Services { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }  // Add ProfileDbSet for profiles

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship between ApplicationUser and Profile
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<ProfileModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship between ApplicationUser and Service (NeededServices)
            modelBuilder.Entity<Service>()
                .HasOne(s => s.User)  // User is the owner of NeededServices
                .WithMany(u => u.NeededServices)  // NeededServices collection on ApplicationUser
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship between ApplicationUser and Service (ProvidedServices)
            modelBuilder.Entity<Service>()
                .HasOne(s => s.ProviderUser)  // ProviderUser is the owner of ProvidedServices
                .WithMany(u => u.ProvidedServices)  // ProvidedServices collection on ApplicationUser
                .HasForeignKey(s => s.ProviderUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Ignore the User property in Service to avoid conflict
            modelBuilder.Entity<Service>()
                .Ignore(s => s.User);

            modelBuilder.Entity<Service>()
                .Ignore(s => s.ProviderUser); // Ignore ProviderUser in Service if necessary

            // Configure primary key for Service
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceId);

            // Add any other custom configurations for your entities here
        }
        public DbSet<Tiger_Tasks.Models.ForumPost> ForumPost { get; set; } = default!;
    }
}