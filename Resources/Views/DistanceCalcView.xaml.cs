using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class DistanceCalcView : ContentPage
{

	ViewAirportListModel Airports;
    private List<string> FromToFields;

	public DistanceCalcView()
	{
		Airports = new();
        FromToFields = new();
		InitializeComponent();
		SearchAirport.BindingContext = Airports;
	}

    private async void SearchAirport_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        if (SearchAirport.SelectedValue != null)
        {
            if(FromToFields.Count < 1) 
            {
                string location = SearchAirport.SelectedValue.ToString();
                string airportDetails = await Airports.GetAirportCoordinates(location);
                DepartureAirport.IsVisible = true;
                From.Text = $"{location}, {airportDetails}";
                FromToFields.Add(location);
            }
            else
            {
                string location = SearchAirport.SelectedValue.ToString();
                string airportDetails = await Airports.GetAirportCoordinates(location);
                ArrivalAirport.IsVisible = true;
                To.Text = $"{location}, {airportDetails}";
                FromToFields.Add(location);

                double calcDistance = Airports.GetDistance();
                Distance.Text = $"{calcDistance.ToString()} NM";
            }
        }
    }

    private void ClearFields_Clicked(object sender, EventArgs e)
    {
        Airports.ClearCalculateDistance();
        FromToFields.Clear();
        DepartureAirport.IsVisible = false;
        ArrivalAirport.IsVisible = false;
        From.Text = "";
        To.Text = "";
        Distance.Text = "";
    }
}