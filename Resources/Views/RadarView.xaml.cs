using CommunityToolkit.Maui.Views;
using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class RadarView : ContentPage
{

	ViewRadarModel Radar = new();

	public RadarView()
	{
		InitializeComponent();		
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Radar.GetRadarLink();
		RadarImageDisplay.Source = Radar.RadarLink;
	}
}