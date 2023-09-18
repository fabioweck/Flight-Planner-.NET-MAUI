using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class FlightPackageView : ContentPage
{

	ViewFlightPackageModel FlightPackage;

	public FlightPackageView()
	{
		InitializeComponent();

		FlightPackage = new();
	}

	//This method reloads the page everytime the tab is clicked
    protected override void OnAppearing()
    {
        base.OnAppearing();

        btnWeather_Clicked(Handler, null);
    }

    private void btnWeather_Clicked(object sender, EventArgs e)
    {
		string weather = FlightPackage.GetWeather();
		string sigwx = FlightPackage.GetSigwx();
		string satellite = FlightPackage.GetSatellite();
		Stream chart = FlightPackage.GetChart();

		lblWeather.Text = weather;
		sigwxImage.Source = sigwx;
		satelliteImage.Source = satellite;
		cgImage.Source = ImageSource.FromStream(() => chart);
    }
}