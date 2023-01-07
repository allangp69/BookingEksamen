using System.Net.Http.Headers;
using System.Net.Http.Json;
using BookingEksamenMAUI.Models;
using Microsoft.Extensions.Configuration;

namespace BookingEksamenMAUI.Helpers
{
    public abstract class APIHelperBase
    {
        private readonly IConfiguration _configuration;

        protected APIHelperBase(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeClient();
        }

        protected HttpClient ApiClient { get; set; }

        private void InitializeClient()
        {
            ApiClient = new HttpClient();
            var apiAddress = _configuration.GetSection("ApiAddress").Value;
            ApiClient.BaseAddress = new Uri(apiAddress);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        //public async Task<AuthenticatedUser> Authenticate(string username, string password, string email)
        //{
        //    // var data = new FormUrlEncodedContent(new[]
        //    // {
        //    //     new KeyValuePair<string, string>("grant_type", "password"),
        //    //     new KeyValuePair<string, string>("username", username),
        //    //     new KeyValuePair<string, string>("password", password)
        //    // });
        //    var data = new FormUrlEncodedContent(new[]
        //    {
        //        new KeyValuePair<string, string>("userName", username),
        //        new KeyValuePair<string, string>("email", email),
        //        new KeyValuePair<string, string>("password", password),
        //        new KeyValuePair<string, string>("createdDate", DateTime.UtcNow.ToString("O"))
        //    });

        //    using (HttpResponseMessage response = await ApiClient.PostAsJsonAsync("/api/Token", data))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadAsAsync<AuthenticatedUser>();
        //    }
        //}
    }
}