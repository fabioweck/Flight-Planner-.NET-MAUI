using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class ChartsView : ContentPage
{
    ViewChartsModel charts = new();
    public ChartsView()
	{
		InitializeComponent();
        BindingContext = charts;
	}

    private void GetChart_Clicked(object sender, EventArgs e)
    {
		
    }

    private async void searchChart_Completed(object sender, EventArgs e)
    {
        string location = ((Entry)sender).Text;
        await charts.GetCharts(location);
    }
}