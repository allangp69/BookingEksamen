using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers
{
    public class BookerAPIHelper
        : APIHelperBase, IBookerAPIHelper, IAuthenticationAPIHelper
    {
        public BookerAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Booker>> GetBookersAsync()
        {
            var response = await ApiClient.GetAsync("api/Booker");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Booker>>();
        }

        public async Task<Uri> CreateBookerAsync(Booker booker)
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