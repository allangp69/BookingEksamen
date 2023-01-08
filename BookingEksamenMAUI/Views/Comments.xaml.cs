using BookingEksamenMAUI.ViewModels;

namespace BookingEksamenMAUI.Views;

public partial class CommentsPage : ContentPage
{
    public CommentsPage(CommentViewModel commentViewModel)
	{		
		InitializeComponent();
        BindingContext = commentViewModel;
    }
	
}

