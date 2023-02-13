using MobileClient.ViewModels;

namespace MobileClient.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
	public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}