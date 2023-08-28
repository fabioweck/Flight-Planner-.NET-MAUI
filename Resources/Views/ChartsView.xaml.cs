using MAUIpractice.Resources.Models;
using MAUIpractice.Resources.ViewModels;

namespace MAUIpractice.Resources.Views;

public partial class ChartsView : ContentPage
{
    ViewChartsModel Charts = new();

    public ChartsView()
	{
		InitializeComponent();
        BindingContext = Charts;
	}

    private async void SearchChart_Completed(object sender, EventArgs e)
    {
        ProgressBar.IsIndeterminate = true;
        string location = ((Entry)sender).Text;
        await Charts.GetCharts(location);
        ProgressBar.IsIndeterminate = false;
        ProgressBar.Progress = 100;
    }

    private void ViewCell_Tapped(object sender, EventArgs e)
    {
        var viewCell = (ViewCell)sender;
        var label = (ChartModel)viewCell.BindingContext;

        if (label != null)
        {
            PdfCharts.Source = $"https://drive.google.com/viewer?url={label.Link}";
        }
    }
}