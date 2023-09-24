using LoginwithFirebase.ViewModels;

namespace LoginwithFirebase;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}

	
}

