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
                From.Text = $"{location}, {airportDetails}";
                counter++;
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";
                await OriginAirportStack.FadeTo(1, 500);
            }

            else if(counter == 1)
            {
                location = SearchAirport.SelectedValue.ToString();
                airportDetails = await Airports.GetAirportCoordinates(location);
                To.Text = $"{location}, {airportDetails}";

                calcDistance = Airports.GetDistance();
                Distance.Text = $"{calcDistance.ToString()} NM";
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";
                counter++;
                ClearTime.IsVisible = false;
                ArrivalAirportStack.FadeTo(1, 250);
                Border.FadeTo(1, 250);
                CalcStack.FadeTo(1, 250);
                ClearFields.FadeTo(1, 250);
                
            }

            else
            {
                Airports.RemoveLastAirport();
                location = SearchAirport.SelectedValue.ToString();
                airportDetails = await Airports.GetAirportCoordinates(location);
                await ArrivalAirportStack.FadeTo(0, 100);
                await Border.FadeTo(0, 100);
                await CalcStack.FadeTo(0, 100);

                To.Text = $"{location}, {airportDetails}";
                calcDistance = Airports.GetDistance();

                ClearTime.IsVisible = false;
                Speed.IsVisible = true;
                Speed.Text = "";
                Time.IsVisible = false;

                Distance.Text = $"{calcDistance.ToString()} NM";
                SearchAirport.Text = "";
                SearchAirport.Placeholder = "Select destination airport";

                await ArrivalAirportStack.FadeTo(1, 100);
                await Border.FadeTo(1, 100);
                await CalcStack.FadeTo(1, 100);
            }
        }
    }

    private async void ClearFields_Clicked(object sender, EventArgs e)
    {

        Airports.ClearCalculateDistance();
        await ClearFields.FadeTo(0, 80);
        await CalcStack.FadeTo(0, 80);
        await Border.FadeTo(0, 80);
        await ArrivalAirportStack.FadeTo(0, 80);
        await OriginAirportStack.FadeTo(0, 80);
        

        counter = 0;
        From.Text = "";
        To.Text = "";
        Distance.Text = "";
        SearchAirport.Text = "";
        SearchAirport.Placeholder = "Select origin airport";
        
        Speed.IsVisible = true;
        Speed.Text = "";
        Time.IsVisible = false;
        ClearTime.IsVisible = false;
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