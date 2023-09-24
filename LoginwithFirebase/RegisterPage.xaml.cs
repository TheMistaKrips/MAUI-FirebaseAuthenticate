using LoginwithFirebase.ViewModels;

namespace LoginwithFirebase;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(Navigation);
	}
}