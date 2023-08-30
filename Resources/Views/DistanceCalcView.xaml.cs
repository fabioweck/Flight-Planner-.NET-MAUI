using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class DistanceCalcView : ContentPage
{
    private int counter;
    private double calcDistance;
    private string calcTime;
    ViewAirportListModel Airports;

	public DistanceCalcView()
	{
        counter = 0;
        calcDistance = 0;
        calcTime = string.Empty;
		Airports = new();
        counter = 0;
		InitializeComponent();
		SearchAirport.BindingContext = Airports;
	}

    private async void SearchAirport_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        string location = string.Empty;
        string airportDetails = string.Empty;

        if (SearchAirport.SelectedValue != null)
        {
            if(counter == 0) 
            {
                location = SearchAirport.SelectedValue.ToString();
                airportDetails = await Airports.GetAirportCoordinates(location);
                DepartureAirport.IsVisible = true;
                From.Text = $"{location}, {airportDetails}";
                counter++;
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";
            }

            else if(counter == 1)
            {
                location = SearchAirport.SelectedValue.ToString();
                airportDetails = await Airports.GetAirportCoordinates(location);
                ArrivalAirport.IsVisible = true;
                To.Text = $"{location}, {airportDetails}";

                calcDistance = Airports.GetDistance();
                Distance.Text = $"{calcDistance.ToString()} NM";
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";
                counter++;
                Border.IsVisible = true;
                CalcStack.IsVisible = true;
                ClearFields.IsVisible = true;
            }

            else
            {
                Airports.RemoveLastAirport();
                location = SearchAirport.SelectedValue.ToString();
                airportDetails = await Airports.GetAirportCoordinates(location);
                ArrivalAirport.IsVisible = true;
                To.Text = $"{location}, {airportDetails}";

                calcDistance = Airports.GetDistance();

                ClearTime.IsVisible = false;
                Speed.IsVisible = true;
                Speed.Text = "";
                Time.IsVisible = false;

                Distance.Text = $"{calcDistance.ToString()} NM";
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";
            }
        }
    }

    private void ClearFields_Clicked(object sender, EventArgs e)
    {
        Airports.ClearCalculateDistance();
        DepartureAirport.IsVisible = false;
        ArrivalAirport.IsVisible = false;
        CalcStack.IsVisible = false;
        counter = 0;
        From.Text = "";
        To.Text = "";
        Border.IsVisible = false;
        Distance.Text = "";
        SearchAirport.Text = "";
        SearchAirport.Placeholder = "Select origin airport";
        ClearFields.IsVisible = false;
        Speed.IsVisible = true;
        Speed.Text = "";
        Time.IsVisible = false;
    }

    private void Speed_Completed(object sender, EventArgs e)
    {
        int speed = Convert.ToInt32(((Entry)sender).Text);
        calcTime = Airports.GetTime(calcDistance, speed);
        Speed.IsVisible = false;
        Time.Text = calcTime.ToString();
        Time.IsVisible = true;
        ClearTime.IsVisible = true;
    }

    private void ClearTime_Clicked(object sender, EventArgs e)
    {
        ClearTime.IsVisible = false;
        Speed.IsVisible = true;
        Speed.Text = "";
        Time.IsVisible = false;
    }
}