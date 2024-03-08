using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace ToleratingTyposMAUI;

public partial class MainPage : ContentPage
{
    private List<String> items = new List<string>();

    public List<String> Items
    {
        get { return items; }
        set { items = value; }
    }


    public MainPage()
	{


        Items.Add("Carrots");
        Items.Add("Broccoli");
        Items.Add("Cauliflower");
        Items.Add("Spinach");
        Items.Add("Tomatoes");
        Items.Add("Bell peppers");
        Items.Add("Onions");
        Items.Add("Potatoes");
        Items.Add("Cabbage");
        Items.Add("Zucchini");

        InitializeComponent();

        this.BindingContext = this;
    }


}

