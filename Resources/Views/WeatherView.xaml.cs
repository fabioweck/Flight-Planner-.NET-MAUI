using MAUIpractice.Resources.ViewModels;
using Microsoft.Maui.Devices.Sensors;
using Syncfusion.Maui.ProgressBar;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Views;

public partial class WeatherView : ContentPage
{
    public ViewWeatherModel GetWeather { get; set; }
    public ViewFavoritesModel GetFavorites { get; set; }
    public WeatherView()
    {
        InitializeComponent();

        GetWeather = new ViewWeatherModel();
        GetFavorites = new ViewFavoritesModel();

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

}