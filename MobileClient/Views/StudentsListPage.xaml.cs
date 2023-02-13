using MobileClient.ViewModels;

namespace MobileClient.Views;

public partial class StudentsListPage : ContentPage
{
	private StudentListPageViewModel _viewModel;

	public StudentsListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}
	
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(null);
    }
}