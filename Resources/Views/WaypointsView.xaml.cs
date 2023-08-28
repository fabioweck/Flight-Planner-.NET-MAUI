using MAUIpractice.Resources.ViewModels;
using Syncfusion.Maui.Inputs;

namespace MAUIpractice.Resources.Views;

public partial class WaypointsView : ContentPage
{


    public WaypointsView()
	{
		InitializeComponent();
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        
    }

    private void AutoComplete_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        //autoComplete.SelectedValue to get the value from selection;
    }


}