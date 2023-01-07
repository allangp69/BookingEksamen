using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace BookingEksamenMAUI.Helpers.Booker
{
    public class BookerAPIHelper
        : APIHelperBase, IBookerAPIHelper
    {
        public BookerAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Models.Booker>> GetBookersAsync()
        {
            var response = await ApiClient.GetAsync("api/Booker");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Models.Booker>>();
        }

        public async Task<Uri> CreateBookerAsync(Models.Booker booker)
        {
            HttpResponseMessage response = await ApiClient.PostAsJsonAsync("api/Booker", booker);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        
        public async Task<HttpStatusCode> DeleteBookerAsync(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"api/Booker/{id}");
            return response.StatusCode;
        }
        
    }
}