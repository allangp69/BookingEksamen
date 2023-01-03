using System.ComponentModel.DataAnnotations;

namespace BookingEksamenMAUI.Models;

public class Comment
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public string EmailAddress { get; set; }
    [DataType(DataType.MultilineText)]
    public string CommentText { get; set; }
}