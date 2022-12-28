using System.Net;
using System.Net.Http.Headers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenUI.Helpers
{
    public abstract class APIHelper
    {
        private readonly IConfiguration _configuration;

        public APIHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeClient();
        }
        public HttpClient ApiClient { get; set; }

        public void InitializeClient()
        {
            ApiClient = new HttpClient();
            string apiAddress = _configuration.GetSection("ApiAddress").Value;
            ApiClient.BaseAddress = new Uri(apiAddress);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await ApiClient.PostAsync("/api/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}