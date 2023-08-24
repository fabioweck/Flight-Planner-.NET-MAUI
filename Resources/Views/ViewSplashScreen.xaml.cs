namespace MAUIpractice.Resources.Views;

public partial class ViewSplashScreen : ContentPage
{
	public ViewSplashScreen()
	{
		InitializeComponent();
        SplashScreenTimer();
    }

    private async void SplashScreenTimer()
    {
        await Task.Delay(3000);
        Navigation.PushModalAsync(new MainPage());
    }
}