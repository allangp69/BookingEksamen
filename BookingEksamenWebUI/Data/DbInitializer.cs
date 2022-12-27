using Microsoft.EntityFrameworkCore;

namespace BookingEksamen.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();
    }
}