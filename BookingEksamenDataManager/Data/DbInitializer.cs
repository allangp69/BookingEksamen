using BookingEksamenDataManager.Models;

namespace BookingEksamenDataManager.Data;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        if (context.Database.EnsureCreated())
        {
            Seed(context);
        }
    }

    private static void Seed(DatabaseContext context)
    {
        var artists = new List<Artist>
        {
            new Artist
            {
                Name = "The Perfect Dinner Band", ShortDescription = "The perfect band to deliver dinner music",
                LongDescription = "The perfect band to deliver dinner music"
            },
            new Artist
            {
                Name = "The Funny StandUp Guy", ShortDescription = "The funniest man on earth",
                LongDescription = "The funniest man on earth"
            },
            new Artist
            {
                Name = "The Laid Back Jazz Band", ShortDescription = "The coolest jazz band in the galaxy",
                LongDescription = "The coolest jazz band in the galaxy"
            },
        };
        artists.ForEach(a => context.Artists.Add(a));
        context.SaveChanges();

        var bookers = new List<Booker>
        {
            new Booker {Name = "Allan G. Pedersen", Email = "allangpedersen@yahoo.dk"},
            new Booker {Name = "Karl Einer", Email = "karleiner@bookingdawdaw.dk"}
        };
        bookers.ForEach(b => context.Bookers.Add(b));
        context.SaveChanges();

        var comments = new List<Comment>
        {
            new Comment
            {
                LastName = "Pedersen", FirstMidName = "Allan Grønbæk", EmailAddress = "allangpedersen@yahoo.dk",
                CommentText = "Dette er en lille kommentar - vil bare teste om det virker"
            }
        };
        comments.ForEach(c => context.Comments.Add(c));
        context.SaveChanges();

        var userInfos = new List<UserInfo>
        {
            new UserInfo
            {
                DisplayName = "Allan G. Pedersen",
                UserName = "AllanGPedersen",
                Email = "allangpedersen@yahoo.dk",
                Password = "Agp@123456",
                CreatedDate = DateTime.UtcNow
            }
        };
        userInfos.ForEach(u => context.UserInfos.Add(u));
        context.SaveChanges();
    }
}