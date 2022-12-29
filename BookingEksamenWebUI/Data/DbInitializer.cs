using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookingEksamenWebUI.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();
        Seed(roleManager);
    }

    private static void Seed(RoleManager<IdentityRole> roleManager)
    {
        roleManager.CreateAsync(new IdentityRole("Admin"));
        roleManager.CreateAsync(new IdentityRole("Booker"));
        roleManager.CreateAsync(new IdentityRole("Artist"));
    }
}