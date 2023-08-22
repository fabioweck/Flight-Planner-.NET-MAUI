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

    private async void airportEntry_Completed(object sender, EventArgs e)
    {
        airport.Clear();
        string airportSearch = ((Entry)sender).Text;
        string response = await airport.ConvertXml(airportSearch);
        //rotaer.Source = "https://drive.google.com/viewerng/viewer?url=https://aisweb.decea.gov.br/download/?arquivo=e5bada5a-2c12-472b-bb5f1e9f5b3f01c1&amp";
        rotaer.Source = new HtmlWebViewSource
        {
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
}
