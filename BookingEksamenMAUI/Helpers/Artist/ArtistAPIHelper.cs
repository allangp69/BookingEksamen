using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace BookingEksamenMAUI.Helpers.Artist
{
    public class ArtistAPIHelper
        : APIHelperBase, IArtistAPIHelper, IAuthenticationAPIHelper
    {
        public ArtistAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Models.Artist>> GetArtistsAsync()
        {
            var response = await ApiClient.GetAsync("api/Artist");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Models.Artist>>();
        }

        public async Task<Uri> CreateArtistAsync(Models.Artist artist)
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