using MAUIpractice.Resources.ViewModels;
using Syncfusion.Maui.Charts;

namespace MAUIpractice.Resources.Views;

public partial class WeightAndBalanceView : ContentPage
{

	ViewWeightModel WeightAndBalanceData { get; set; }
    ViewPayloadModel PayloadColumn { get; set; }
    List<Entry> Entries { get; set; }
    List<Label> Moments { get; set; }
    double[] Arms { get; set; }

	public WeightAndBalanceView()
	{
		WeightAndBalanceData = new();
        PayloadColumn = new();
        Entries = new();
        Moments = new();
        Arms = PayloadColumn.GetArms();
        InitializeComponent();
		BindingContext = WeightAndBalanceData;
        AddFields();
	}

    private void AddFields()
    {
        string[] fields = PayloadColumn.GetFields();      

        for(int i = 0; i < fields.Length; i++)
        {
            HorizontalStackLayout PayloadComputations = new();
            PayloadComputations.Spacing = 20;

            //Creates first column
            Label field = new() 
            {
                Text = fields[i],
                FontSize = 13,
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 200,
            };
            PayloadComputations.Add(field);

            Entry entry = new()
            {
                Text = "0",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 50,
            };
            PayloadComputations.Add(entry);
            Entries.Add(entry);

            Border border = new Border();
            PayloadComputations.Add(border);

            Label Arm = new()
            {
                Text = Arms[i].ToString(),
                FontSize = 15,
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 40,
            };
            PayloadComputations.Add(Arm);

            Border newBorder = new Border();
            PayloadComputations.Add(newBorder);

            Label moment = new()
            {
                FontSize = 15,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                WidthRequest = 65,
            };
            PayloadComputations.Add(moment);
            Moments.Add(moment);

            //Adds the whole content to payload vertical stack layout
            Payload.Add(PayloadComputations);
        }
        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        double sum = 0;
        for(int i = 0; i < Entries.Count; i++)
        {
            Moments[i].Text = Convert.ToString
                (
                    Math.Round((Convert.ToDouble(Entries[i].Text) * Arms[i]) / 100, 2)
                );
        }

        foreach(var item in Moments)
        {
            sum += Convert.ToDouble(item.Text);
        }

        //Total.Text = Math.Round(sum, 2).ToString();

    }
}