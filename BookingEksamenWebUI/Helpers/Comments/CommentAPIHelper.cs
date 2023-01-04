using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers
{
    public class CommentAPIHelper
        : APIHelperBase, ICommentAPIHelper, IAuthenticationAPIHelper
    {
        public CommentAPIHelper(IConfiguration configuration)
            :base(configuration)
        {
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            var response = await ApiClient.GetAsync("api/Comment");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Comment>>();
        }
        
        public async Task<Comment> GetCommentAsync(int id)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"api/Comment/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Comment>();
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