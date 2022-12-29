using System.Net.Http.Headers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers
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
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<AuthenticatedUser>();
            }
        }
    }
}