using System.Net;

namespace BookingEksamenMAUI.Helpers.Artist;

public interface IArtistAPIHelper
{
    Task<IEnumerable<Models.Artist>> GetArtistsAsync();
    Task<Uri> CreateArtistAsync(Models.Artist artist);
    Task<HttpStatusCode> DeleteArtistAsync(int id);
}