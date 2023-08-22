using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class AirportView : ContentPage
{
    public ViewAirportModel airport;
    public AirportView()
	{
        airport = new ViewAirportModel();
        InitializeComponent();
	}

    private async void airportEntry_Completed(object sender, EventArgs e)
    {
        airport.Clear();
        airportView.Text = "";
        string airportSearch = ((Entry)sender).Text;
        string response = await airport.ConvertXml(airportSearch);
        airportView.Text = response;
    }
}