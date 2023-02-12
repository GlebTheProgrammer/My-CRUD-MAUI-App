using Mobile.ViewModels;

namespace Mobile;

public partial class AddEmployee : ContentPage
{
	public AddEmployee(AddEmployeeViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}