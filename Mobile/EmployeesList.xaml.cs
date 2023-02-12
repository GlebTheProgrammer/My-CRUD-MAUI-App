using Mobile.ViewModels;

namespace Mobile;

public partial class EmployeesList : ContentPage
{
	public EmployeesViewModel _viewModel;

	public EmployeesList(EmployeesViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		{
			_viewModel.GetEmployeesListCommand.Execute(null);
		}
    }
}