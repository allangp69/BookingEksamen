using System.Net;
using System.Net.Http.Json;
using BookingEksamenMAUI.Models;
using Microsoft.Extensions.Configuration;

namespace BookingEksamenMAUI.Helpers.Comments
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
            IEnumerable<Comment> comments = null;
            HttpResponseMessage response = await ApiClient.GetAsync("api/Comment");
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