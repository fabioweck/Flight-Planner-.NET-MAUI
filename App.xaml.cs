namespace MAUIpractice
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY0MjY2N0AzMjMyMmUzMDJlMzBGN25mUGh3S1BzZGdhRlBiclVzMDltV045UkxERzFLdGRpTlpFKy9MS0w4PQ==");

            InitializeComponent();

            MainPage = new MainPage();

        }
    }
}