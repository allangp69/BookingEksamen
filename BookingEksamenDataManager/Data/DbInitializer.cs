using BookingEksamenDataManager.Models;

namespace BookingEksamenDataManager.Data;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        if(context.Database.EnsureCreated())
        {
            Seed(context); 
        }            
    }

    private static void Seed(DatabaseContext context)
    {
        var artists = new List<Artist>
        {
            new Artist{Name="The Perfect Dinner Band", ShortDescription="The perfect band to deliver dinner music", LongDescription = "The perfect band to deliver dinner music"},
            new Artist{Name="The Funny StandUp Guy", ShortDescription="The funniest man on earth", LongDescription = "The funniest man on earth"},
            new Artist{Name="The Laid Back Jazz Band", ShortDescription="The coolest jazz band in the galaxy", LongDescription = "The coolest jazz band in the galaxy"},
        };
        artists.ForEach(g => context.Artists.Add(g));
        context.SaveChanges();
    }
}