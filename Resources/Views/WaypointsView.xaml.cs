using MAUIpractice.Resources.ViewModels;
using Syncfusion.Maui.Inputs;
using System.Globalization;
using System.Reflection;

namespace MAUIpractice.Resources.Views;

public partial class WaypointsView : ContentPage
{
    ViewWaypointsModel ViewWaypoints { get; set; }
    ViewAirportListModel ViewAirportList { get; set; }
    private static string waypointSelected;
    private List<string> listOfWaypoints;

    public WaypointsView()
	{
		InitializeComponent();
        ViewWaypoints = new();
        ViewAirportList = new();
        AutoComplete.BindingContext = ViewAirportList;
        waypointSelected = string.Empty;
        listOfWaypoints = new();
    }


    private void Button_Clicked(object sender, EventArgs e)
    {

        //Fading test

        if(FadeMe.Opacity == 0)
        {
            Waypoints.IsVisible = true;
            FadeMe.FadeTo(1, 1000);
        }
        else
        {
            FadeMe.FadeTo(0, 1000);
        }
        
        

        //listOfWaypoints.Add(waypointSelected);
        
        //if(listOfWaypoints.Count > 1 )
        //{
        //    Waypoints.Text = Convert.ToString(ViewWaypoints.GetDistance(Convert.ToInt32(listOfWaypoints[0]), Convert.ToInt32(listOfWaypoints[1])));
        //}
    }

    private void AutoComplete_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        //autoComplete.SelectedValue to get the value from selection;
        if(AutoComplete.SelectedValue != null)
        {
            waypointSelected = AutoComplete.SelectedValue.ToString();
        }
        else
        {
            return;
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        PathLocation.Text = string.Empty;

        PathLocation.Text = "File written";
    }
}