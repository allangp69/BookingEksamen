using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers
{
    public class ArtistAPIHelper
        : APIHelperBase, IArtistAPIHelper, IAuthenticationAPIHelper
    {
        public ArtistAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            IEnumerable<Artist> artists = null;
            HttpResponseMessage response = await ApiClient.GetAsync("api/Artist");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Artist>>();
        }

        public async Task<Uri> CreateArtistAsync(Artist artist)
        {
            HttpResponseMessage response = await ApiClient.PostAsJsonAsync("api/Artist", artist);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        
        public async Task<HttpStatusCode> DeleteArtistAsync(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"api/Artist/{id}");
            return response.StatusCode;
        }
        
    }
}