using BookingEksamenWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Comment> Comments { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
        //     {
        //         new IdentityRole {
        //             Id = Guid.NewGuid().ToString(),
        //             Name = "Admin", 
        //             NormalizedName = "ADMIN"
        //         },
        //         new IdentityRole {
        //             Id = Guid.NewGuid().ToString(),
        //             Name = "Booker", 
        //             NormalizedName = "BOOKER"
        //         },
        //         new IdentityRole {
        //             Id = Guid.NewGuid().ToString(),
        //             Name = "Artist", 
        //             NormalizedName = "ARTIST"
        //         }
        //     });
        // }
    }
}