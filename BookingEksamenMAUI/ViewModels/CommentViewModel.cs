using System.ComponentModel;
using BookingEksamenMAUI.Helpers.Comments;
using BookingEksamenMAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookingEksamenMAUI.ViewModels
{
    public partial class CommentViewModel : ObservableObject
    {
        private readonly ICommentAPIHelper _commentApiHelper;

        public CommentViewModel(ICommentAPIHelper commentApiHelper)
        {
            _commentApiHelper = commentApiHelper;
            Comments = _commentApiHelper.GetComments().ToList();
        }

        [ObservableProperty]
        private List<Comment> comments;

    }
}
