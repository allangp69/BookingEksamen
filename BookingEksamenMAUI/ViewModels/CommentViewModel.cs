using System.ComponentModel;
using BookingEksamenMAUI.Helpers.Comments;
using BookingEksamenMAUI.Models;

namespace BookingEksamenMAUI.ViewModels
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        private readonly ICommentAPIHelper _commentApiHelper;

        public CommentViewModel(ICommentAPIHelper commentApiHelper)
        {
            _commentApiHelper = commentApiHelper;
            Comments = _commentApiHelper.GetComments().ToList();
        }

        private List<Comment> _comments;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Comment> Comments 
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                OnPropertyChanged("Comments");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) 
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
