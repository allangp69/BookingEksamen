using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers;

public interface IArtistAPIHelper
{
    Task<IEnumerable<Artist>> GetArtistsAsync();
    Task<Uri> CreateArtistAsync(Artist artist);
    Task<HttpStatusCode> DeleteArtistAsync(int id);
}