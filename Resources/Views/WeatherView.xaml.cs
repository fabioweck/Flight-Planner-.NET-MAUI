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

    private void FavoritesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
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
}