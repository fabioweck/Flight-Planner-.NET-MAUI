using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class WaypointsView : ContentPage
{
    ViewWaypointsModel waypointsModel = new ViewWaypointsModel();
    public WaypointsView()
	{
		InitializeComponent();
        BindingContext = waypointsModel;
	}

    private async void waypointSearch_Completed(object sender, EventArgs e)
    {
        string waypoint = ((Entry)sender).Text;
        string response = await waypointsModel.ConvertXml(waypoint);
    }
}