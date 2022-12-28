using System.Net;
using System.Net.Http.Headers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenUI.Helpers
{
    public class CommentAPIHelper
        : APIHelper
    {
        private readonly IConfiguration _configuration;

        public CommentAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            IEnumerable<Comment> comments = null;
            HttpResponseMessage response = await ApiClient.GetAsync("api/Comment");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Comment>>();
        }

        public async Task<Uri> CreateCommentAsync(Comment comment)
        {
            HttpResponseMessage response = await ApiClient.PostAsJsonAsync("api/Comment", comment);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        
        public async Task<HttpStatusCode> DeleteCommentAsync(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"api/Comment/{id}");
            return response.StatusCode;
        }
        
    }
}