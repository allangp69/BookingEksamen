using BookingEksamenMAUI.ViewModels;

namespace BookingEksamenMAUI.Views;

public partial class CommentsPage : ContentPage
{
    private readonly CommentViewModel _commentViewModel;

    public CommentsPage(CommentViewModel commentViewModel)
	{		
		InitializeComponent();
        _commentViewModel = commentViewModel;
    }
	
}

