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

    private void btnWeather_Clicked(object sender, EventArgs e)
    {
		string weather = FlightPackage.GetWeather();
		string sigwx = FlightPackage.GetSigwx();
		string satellite = FlightPackage.GetSatellite();

		lblWeather.Text = weather;
		sigwxImage.Source = sigwx;
		satelliteImage.Source = satellite;

    }
}