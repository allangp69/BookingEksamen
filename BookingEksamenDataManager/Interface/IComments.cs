using BookingEksamenDataManager.Models;

namespace BookingEksamenDataManager.Interface;

public interface IComments
{
    public List<Comment> GetCommentDetails();
    public Comment GetCommentDetails(int id);
    public void AddComment(Comment comment);
    public void UpdateComment(Comment comment);
    public Comment DeleteComment(int id);
    public bool CheckComment(int id);
}