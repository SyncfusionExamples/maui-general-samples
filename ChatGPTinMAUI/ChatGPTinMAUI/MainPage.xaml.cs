using ChatGptNet;
using ChatGptNet.Models;
using Syncfusion.Maui.Maps;

namespace ChatGPTinMAUI;

public partial class MainPage : ContentPage
{

    public String Title
    {
        get { return (String)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(String), typeof(MainPage), String.Empty);

    public String ContentText
    {
        get { return (String)GetValue(ContentTextProperty); }
        set { SetValue(ContentTextProperty, value); }
    }

    public static readonly BindableProperty ContentTextProperty =
        BindableProperty.Create("ContentText", typeof(String), typeof(MainPage), String.Empty);

    private IChatGptClient _chatGptClient;
    private Guid _sessionGuid = Guid.Empty;
    MapMarkerCollection mapMarkers = new MapMarkerCollection();
    MapMarker mapMarker = new MapMarker();

    public MainPage()
    {
        InitializeComponent();
       
        this.Loaded += MainPage_Loaded;
        (this.maps.Layer as MapTileLayer).Tapped += MainPage_Tapped;
        mapMarkers.Add(mapMarker);

        this.BindingContext = this;
    }


    private void MainPage_Loaded(object sender, EventArgs e)
       {
           _chatGptClient = Handler.MauiContext.Services.GetService<IChatGptClient>();
       }

    private async void MainPage_Tapped(object sender, Syncfusion.Maui.Maps.TappedEventArgs e)
    {
        var latlong = (this.maps.Layer as MapTileLayer).GetLatLngFromPoint(e.Position);

        var geoLocation = "Latitude:"+ latlong.Latitude.ToString() + ",Longitude:" + latlong.Longitude.ToString();

        await GetNearByTouristAttraction(geoLocation);
        this.popupDisplay.Show(e.Position.X, e.Position.Y);
        this.popupDisplay.Show(e.Position.X, e.Position.Y);
    }

    private async Task GetNearByTouristAttraction(string geoLocation)
    {
        this.busyIndicator.IsRunning = true;
        if (string.IsNullOrWhiteSpace(geoLocation))
        {
            await DisplayAlert("Empty location", "No Suggestions", "OK");
            return;
        }

        if (_sessionGuid == Guid.Empty)
        {
            _sessionGuid = Guid.NewGuid();
        }

        var query = "Tell me 5 places near the following location (Each with 20 words) " + geoLocation;
        ChatGptResponse response = await _chatGptClient.AskAsync(_sessionGuid, query);
        this.ContentText = response.GetMessage();
        this.busyIndicator.IsRunning = false;
    }

 
}
