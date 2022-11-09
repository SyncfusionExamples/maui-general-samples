namespace MAUI7Features;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.mouseClickImage.Source = "mouseleftclick.png";
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        this.mouseClickImage.Source = "mouserightclick.png";
    }
}

