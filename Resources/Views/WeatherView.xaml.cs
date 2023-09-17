using MAUIpractice.Resources.Models;
using MAUIpractice.Resources.ViewModels;
using Microsoft.Maui.Devices.Sensors;
using Syncfusion.Maui.ProgressBar;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MAUIpractice.Resources.Views;

public partial class WeatherView : ContentPage
{
    ViewWeatherModel GetWeather { get; set; }
    ViewFavoritesModel GetFavorites { get; set; }
    ViewSigwxModel GetSigwx { get; set; }
    ViewRadarModel GetRadar { get; set; }
    ViewFlightPackageModel FlightPackage { get; set; }

    DataTemplate contentTemplateView;
    Image sigwxImage;
    Image radarImage;

    public WeatherView()
    {
        InitializeComponent();

        GetWeather = new ViewWeatherModel();
        GetFavorites = new ViewFavoritesModel();
        GetSigwx = new ViewSigwxModel();
        GetRadar = new ViewRadarModel();
        FlightPackage = new ViewFlightPackageModel();

        WeatherList.BindingContext = GetWeather;
        FavoritesList.BindingContext = GetFavorites;
        BindingContext = GetWeather;

    }

    private void WeatherLocation_Completed(object sender, EventArgs e)
    {
        
        string location = ((Entry)sender).Text;
        LoadWeatherAndProgress(location);  

    }

    private async Task LoadWeather(string location)
    {
        await GetWeather.AddWeather(location);

    }

    private async Task LoadWeatherAndProgress(string location)
    {
        await Task.WhenAll(LoadWeather(location), LoadProgressBar());
    }

    private async Task LoadProgressBar()
    {
        for (var i = 0; i <= 100; i++)
        {
            await Task.Delay(1);
            ProgressBar.Progress = i;
        }

    }

    private void ClearWeatherField_Clicked(object sender, EventArgs e)
    {
        GetWeather.ClearWeather();
    }

    private void AddFavorite_Clicked(object sender, EventArgs e)
    {
        string location;

        if (string.IsNullOrEmpty(AddFavoriteToList.Text))
        {
            FavoriteResponse.Text = "Invalid input.";
            return;
        }

        location = AddFavoriteToList.Text.ToUpper();
        string response = GetFavorites.AddFavorite(location);
        FavoriteResponse.Text = response;
    }

    private void ViewCell_Tapped(object sender, EventArgs e)
    {
        var viewCell = (ViewCell)sender;
        var label = (Label)viewCell.View.FindByName("FavoriteClicked");

        if (label != null)
        {
            LoadWeatherAndProgress(label.Text);
        }
    }

    private async Task LoadSigwxAndProgressBar()
    {
        await Task.WhenAll(LoadSigwxContent(), LoadProgressBar());
    }

    private async Task LoadRadarAndProgressBar()
    {
        await Task.WhenAll(LoadRadarContent(), LoadProgressBar());
    }

    private async Task LoadSigwxContent()
    {
        await GetSigwx.GetSigwxLink();
        string link = GetSigwx.GetLink();

        contentTemplateView = new DataTemplate(() =>
        {
            sigwxImage = new Image();
            sigwxImage.BackgroundColor = Colors.Transparent;
            sigwxImage.Margin = 10;
            sigwxImage.Source = link;

            sigwxImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    // Handle the right-click-like action here
                    // You can extract information or perform any other action
                    // when the image is long-pressed (simulated right-click)
                    bool add = await DisplayAlert("SIGWX", "Would you like to add to your current Flight Package?", "Add", "Cancel");

                    if(add)
                    {
                        FlightPackage.AddSigwx(link);
                    }

                }),
                NumberOfTapsRequired = 2
            });

            return sigwxImage;
        });

        SigwxPopup.ContentTemplate = contentTemplateView;   
        SigwxPopup.Show();
    }

    private async Task LoadRadarContent()
    {
        await GetRadar.GetRadarLink();
        string link = GetRadar.GetLink();
        string date = GetRadar.GetDate();

        contentTemplateView = new DataTemplate(() =>
        {
            radarImage = new Image();
            radarImage.Margin = 10;
            radarImage.Source = link;

            radarImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    // Handle the right-click-like action here
                    // You can extract information or perform any other action
                    // when the image is long-pressed (simulated right-click)
                    bool add = await DisplayAlert("SIGWX", "Would you like to add to your current Flight Package?", "Add", "Cancel");

                    if (add)
                    {
                        FlightPackage.AddSatellite(link);
                    }

                }),
                NumberOfTapsRequired = 2
            });

            return radarImage;
        });

        RadarPopup.HeaderTitle = $"Enhanced - {date}";
        RadarPopup.ContentTemplate = contentTemplateView;
        RadarPopup.Show();
    }

    private void SigwxDisplay_Clicked(object sender, EventArgs e)
    {
        LoadSigwxAndProgressBar();
    }

    private void RadarDisplay_Clicked(object sender, EventArgs e)
    {
        LoadRadarAndProgressBar();
    }

    private void AddToFlightPackage_Clicked(object sender, EventArgs e)
    {
        // Find the ListViewItem associated with the clicked MenuItem
        if (sender is MenuItem menuItem && menuItem.BindingContext is MetarTafModel dataItem)
        {
            // Find the "lblMetar" Label within the ListViewItem
            Label lblMetar = (Label)menuItem.Parent.FindByName("lblMetar");
            Label lblTaf = (Label)menuItem.Parent.FindByName("lblTaf");

            if (lblMetar != null)
            {
                string weather = $"{lblMetar.Text}\n{lblTaf.Text}";
                FlightPackage.AddWeather(weather);
            }
        }
    }
}