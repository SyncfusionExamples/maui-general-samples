namespace ShellPageNavigation;

public partial class FlyMenuPage : ContentPage
{
	int count = 0;

	public FlyMenuPage()
	{
		InitializeComponent();
	}

}

public class FlyoutPageItem
{
    public string Title { get; set; }
    public string IconSource { get; set; }
    public Type TargetType { get; set; }
}

