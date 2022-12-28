using BookingEksamenDataManager.Data;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Repository;

public class CommentRepository
    :IComments
{
    private readonly DatabaseContext _databaseContext;

    public CommentRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public List<Comment> GetCommentDetails()
    {
        return _databaseContext.Comments.ToList();
    }

    public Comment GetCommentDetails(int id)
    {
        return _databaseContext.Comments.Find(id);
    }

    public void AddComment(Comment comment)
    {
        _databaseContext.Comments.Add(comment);
        _databaseContext.SaveChanges();
    }

    public void UpdateComment(Comment comment)
    {
        _databaseContext.Entry(comment).State = EntityState.Modified;
        _databaseContext.SaveChanges();
    }

    public Comment DeleteComment(int id)
    {
        var comment = _databaseContext.Comments.Find(id);

        if (comment is null)
        {
            throw new ArgumentNullException();
        }
        _databaseContext.Comments.Remove(comment);
        _databaseContext.SaveChanges();
        return comment;
    }

    public bool CheckComment(int id)
    {
        return _databaseContext.Comments.Any(a => a.Id == id);
    }
}