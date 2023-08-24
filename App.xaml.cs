using MAUIpractice.Resources.Views;

namespace MAUIpractice
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY0MjY2N0AzMjMyMmUzMDJlMzBGN25mUGh3S1BzZGdhRlBiclVzMDltV045UkxERzFLdGRpTlpFKy9MS0w4PQ==");

            InitializeComponent();

        }
        protected override Window CreateWindow(IActivationState activationState) =>
        new Window(new ViewSplashScreen())
        {
            Width = 1300,
            Height = 800,
            X = 100,
            Y = 10
        };
    }
}