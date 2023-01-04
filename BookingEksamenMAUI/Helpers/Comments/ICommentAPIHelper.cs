using System.Net;
using BookingEksamenMAUI.Models;

namespace BookingEksamenMAUI.Helpers.Comments;

public interface ICommentAPIHelper
{
    IEnumerable<Comment> GetComments();
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment> GetCommentAsync(int id);
    Task<Uri> CreateCommentAsync(Comment comment);
    Task<HttpStatusCode> DeleteCommentAsync(int id);
}