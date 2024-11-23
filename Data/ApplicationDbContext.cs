using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tiger_Tasks.Models;

namespace Tiger_Tasks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        [Required] public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<Service> Services { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship between ApplicationUser and Service (NeededServices)
            modelBuilder.Entity<Service>()
                .HasOne(s => s.User)
                .WithMany(u => u.NeededServices)  // 'NeededServices' collection on ApplicationUser
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship between ApplicationUser and Service (ProvidedServices)
            modelBuilder.Entity<Service>()
                .HasOne(s => s.ProviderUser)
                .WithMany(u => u.ProvidedServices)  // 'ProvidedServices' collection on ApplicationUser
                .HasForeignKey(s => s.ProviderUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .Ignore(s => s.User);

          //  modelBuilder.Entity<Service>()
            //    .HasKey(s => s.ServiceId);
        }
        /* protected override void OnModelCreating(ModelBuilder builder)
         {
             base.OnModelCreating(builder);

             // Needed Services relationship
             builder.Entity<ApplicationUser>()
                 .HasMany(a => a.NeededServices)
                 .WithOne(s => s.User)
                 .HasForeignKey(s => s.UserId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .HasConstraintName("FK_Service_Users_NeededServices");

             // Provided Services relationship
             builder.Entity<ApplicationUser>()
                 .HasMany(a => a.ProvidedServices)
                 .WithOne(s => s.User)
                 .HasForeignKey(s => s.UserId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .HasConstraintName("FK_Service_Users_ProvidedServices");

             // Configure the Service entity
             builder.Entity<Service>()
                 .HasKey(s => s.ServiceId); // Ensure ServiceId is the primary key
         }*/

    }
}
