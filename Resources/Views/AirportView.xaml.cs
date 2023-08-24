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

    private async Task LoadRotaer(string location)
    {
        airport.Clear();
        string response = await airport.ConvertXml(location);
        rotaer.Source = new HtmlWebViewSource
        {
            //#1c1c1c background color
            Html = @"<!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Document</title>
                    <style>
                        html, body{ background-color: #1c1c1c; font-family: 'Calibri'; color: white; }
                    </style>
                    </head>
                    <body>" + response + @"</body></html>"
        };
    }

    private async Task LoadRotaerAndProgress(string location)
    {
        await Task.WhenAll(LoadRotaer(location), LoadProgressBar());
        ProgressBar.IsIndeterminate = false;
        ProgressBar.Progress = 100;
    }

    private async Task LoadProgressBar()
    {
        ProgressBar.IsIndeterminate = true;
    }

    private async void airportEntry_Completed(object sender, EventArgs e)
    {
        string location = ((Entry)sender).Text;
        await LoadRotaerAndProgress(location);
    }
}
