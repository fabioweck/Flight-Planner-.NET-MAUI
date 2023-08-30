using MAUIpractice.Resources.ViewModels;
using Syncfusion.Maui.Inputs;

namespace MAUIpractice.Resources.Views;

public partial class AirportView : ContentPage
{
    public ViewAirportModel Airport;
    public ViewAirportListModel AirportList;

    public AirportView()
    {
        Airport = new ViewAirportModel();
        AirportList = new();
        InitializeComponent();
        SearchAirport.BindingContext = AirportList;
    }

    private async Task LoadRotaer(string location)
    {
        Airport.Clear();
        string response = await Airport.ConvertXml(location);
        Rotaer.Source = new HtmlWebViewSource
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

    private async void SearchAirport_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        if(SearchAirport.SelectedValue != null)
        {
            string location = SearchAirport.SelectedValue.ToString();
            await LoadRotaerAndProgress(location);
        }
        
    }
}
