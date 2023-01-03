using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers
{
    public class HeavyWorkloadAPIHelper
        : APIHelperBase, IHeavyWorkloadAPIHelper, IAuthenticationAPIHelper
    {
        public HeavyWorkloadAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<string> DoHeavyWorkloadAsync()
        {
            HttpResponseMessage response = await ApiClient.GetAsync("api/HeavyWorkload");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<string>();
        }
        
        public string DoHeavyWorkload()
        {
            HttpResponseMessage response = ApiClient.Send( new HttpRequestMessage(HttpMethod.Get, "api/HeavyWorkload"));
            response.EnsureSuccessStatusCode();
            var reader = new StreamReader(response.Content.ReadAsStream());
            return reader.ReadToEnd();
        }
        
        public async Task<string> DoNormalWorkloadAsync()
        {
            HttpResponseMessage response = await ApiClient.GetAsync("api/NormalWorkload");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<string>();
        }
        
        public string DoNormalWorkload()
        {
            HttpResponseMessage response = ApiClient.Send( new HttpRequestMessage(HttpMethod.Get, "api/NormalWorkload"));
            response.EnsureSuccessStatusCode();
            var reader = new StreamReader(response.Content.ReadAsStream());
            return reader.ReadToEnd();
        }
        
        
    }
}