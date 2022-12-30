using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers;

public interface ICommentAPIHelper
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment> GetCommentAsync(int id);
    Task<Uri> CreateCommentAsync(Comment comment);
    Task<HttpStatusCode> DeleteCommentAsync(int id);
}