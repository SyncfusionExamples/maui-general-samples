using System.Diagnostics;
using System.Windows.Input;

namespace FormattedText;

public partial class MainPage : ContentPage
{
	int count = 0;

	public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{

	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		
    }
}

