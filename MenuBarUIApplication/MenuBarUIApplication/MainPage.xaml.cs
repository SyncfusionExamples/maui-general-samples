namespace MenuBarUIApplication;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void MenuFlyoutItem_Clicked(object sender, EventArgs e)
    {
        var result = await OpenPicker(PickOptions.Images);
    }

    async Task<FileResult> OpenPicker(PickOptions imageOption)
    {
        try
        {
            var value = await FilePicker.PickAsync(imageOption);
            if (value != null)
            {
                if (value.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase) ||
                    value.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase))
                {
                    var stream = await value.OpenReadAsync();
                    this.photoViewerImage.Source = ImageSource.FromStream(() => stream);
                }
            }

            return value;
        }
        catch (Exception ex)
        {
        }

        return null;
    }

    private void MenuFlyoutItem_Clicked_1(object sender, EventArgs e)
    {
        this.photoViewerImage.RotateTo(90, 500, Easing.BounceIn);
    }

    private void MenuFlyoutItem_Clicked_2(object sender, EventArgs e)
    {
        this.photoViewerImage.RotateTo(180, 500, Easing.BounceIn);
    }

    private void MenuFlyoutItem_Clicked_3(object sender, EventArgs e)
    {
        this.photoViewerImage.RotateTo(270, 500, Easing.BounceIn);
    }

    private void MenuFlyoutItem_Clicked_4(object sender, EventArgs e)
    {
        this.photoViewerImage.RotateTo(360, 500, Easing.BounceIn);
    }

    private void MenuFlyoutItem_Clicked_5(object sender, EventArgs e)
    {
        this.photoViewerImage.ScaleTo(2, 500, Easing.BounceOut);
    }

    private void MenuFlyoutItem_Clicked_6(object sender, EventArgs e)
    {
        this.photoViewerImage.ScaleTo(1, 500, Easing.BounceOut);
        this.photoViewerImage.RotateTo(0, 500, Easing.BounceIn);
    }
}

