using MAUIpractice.Resources.ViewModels;
using Syncfusion.Maui.Charts;
using System.Xml.Schema;

namespace MAUIpractice.Resources.Views;

public partial class WeightAndBalanceView : ContentPage
{

	ViewWeightModel WeightAndBalanceData { get; set; }
    ViewPayloadModel PayloadColumn { get; set; }
    ViewCustomBrushesModel CustomBrushes { get; set; }

    Dictionary<Entry,Label> EntriesAndMoments { get; set; }
    Dictionary<string, double> FieldsAndArms { get; set; }
    Dictionary<int, double> FuelTank { get; set; }
    
	public WeightAndBalanceView()
	{
		WeightAndBalanceData = new();
        PayloadColumn = new();
        CustomBrushes = new();
        EntriesAndMoments = new();
        FieldsAndArms = new();
        FuelTank = new();
        FieldsAndArms = PayloadColumn.GetPayloadData();
        FuelTank = PayloadColumn.GetFuelTank();

        InitializeComponent();
        AddFields();
      
        SelectTotalFuel.BindingContext = PayloadColumn;
        SelectDestinationFuel.BindingContext = PayloadColumn;
        ComputeFuel.TextColor = Colors.White;

        Chart.BindingContext = WeightAndBalanceData;
        Chart.PaletteBrushes = CustomBrushes.GetBrushes();          

    }

    private void AddFields()
    {
        int[] standards = PayloadColumn.GetStandards();
        int i = 0;

        foreach(var column in FieldsAndArms)
        {
            HorizontalStackLayout PayloadComputations = new();
            PayloadComputations.Spacing = 20;

            //Creates first column
            Label field = new() 
            {
                Text = column.Key,
                FontSize = 13,
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 200,
            };
            PayloadComputations.Add(field);

            Entry entry = new()
            {
                Text = standards[i].ToString(),
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 50,
            };

            i++;
            PayloadComputations.Add(entry);

            Border border = new Border();
            PayloadComputations.Add(border);

            Label Arm = new()
            {
                Text = column.Value.ToString(),
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

            EntriesAndMoments.Add(entry, moment);

            //Adds the whole content to payload vertical stack layout
            Payload.Add(PayloadComputations);

        }
        
    }

    private void Compute_ZFW_Clicked(object sender, EventArgs e)
    {
        double payloadWeight = 0;
        double payloadMoment = 0;
        double zfWeight = 0;
        double zfMoment = 0;
        double zfwCg = 0;

        for (int i = 0; i < EntriesAndMoments.Count; i++)
        {
            EntriesAndMoments.ElementAt(i).Value.Text =
                    ((Convert.ToInt16(EntriesAndMoments.ElementAt(i).Key.Text) * FieldsAndArms.ElementAt(i).Value) / 100).ToString("0.00");

            payloadWeight += Convert.ToInt16(EntriesAndMoments.ElementAt(i).Key.Text);
            payloadMoment += Convert.ToDouble(EntriesAndMoments.ElementAt(i).Value.Text);
        }

        Payload_Weight.Text = payloadWeight.ToString("0.00");
        Payload_Moment.Text = payloadMoment.ToString("0.00");

        zfWeight = payloadWeight + Convert.ToDouble(BEW_Weight.Text);
        zfMoment = payloadMoment + Convert.ToDouble(BEW_Moment.Text);
        zfwCg = (zfMoment / zfWeight) * 100;

        ZFW_Weight.Text = zfWeight.ToString("0.00");
        ZFW_Moment.Text = zfMoment.ToString("0.00");

        ZFW_CG.Text = $"ZFW Center of Gravity: {zfwCg.ToString("0.0")}";

        Chart.BindingContext = null;
        WeightAndBalanceData.SetZeroFuelWeight(zfWeight, zfwCg);
        Chart.BindingContext = WeightAndBalanceData;
        ComputeFuel.IsEnabled = true;

        //ScatterSeries newPoint = new ScatterSeries() {
        //    ItemsSource = WeightAndBalanceData.ZeroFuelWeight,
        //    PointWidth = 15,
        //    XBindingPath = "CenterOfGravity",
        //    YBindingPath = "Weight"

        //};
        //Chart.Series.Add(newPoint);


    }

    private void Compute_Fuel_Clicked(object sender, EventArgs e)
    {

        int totalFuel = Convert.ToInt16(SelectTotalFuel.Text);
        int fuelToDestination = Convert.ToInt16(SelectDestinationFuel.Text);

        double rampWeight = 0;
        double rampMoment = 0;
        double rampCG = 0;

        double takeoffWeight = 0;
        double takeoffMoment = 0;
        double takeofCG = 0;

        double landingWeight = 0;
        double landingMoment = 0;
        double landingCG = 0;

        foreach (var item in FuelTank)
        {
            if (totalFuel == item.Key)
            {
                UseableFuel_Weight.Text = item.Key.ToString();
                UseableFuel_Moment.Text = item.Value.ToString();

                rampWeight = Convert.ToDouble(ZFW_Weight.Text) + item.Key;
                rampMoment = Convert.ToDouble(ZFW_Moment.Text) + item.Value;
                rampCG = (rampMoment / rampWeight) * 100;

                Ramp_Weight.Text = rampWeight.ToString("0.00");
                Ramp_Moment.Text = rampMoment.ToString("0.00");
                Ramp_CG.Text = $"Ramp Center of Gravity: {rampCG.ToString("0.0")}";

                break;
            }
        }

        foreach (var item in FuelTank)
        {
            if (item.Key == 200)
            {
                TaxiFuel_Weight.Text = item.Key.ToString();
                TaxiFuel_Moment.Text = item.Value.ToString();

                takeoffWeight = rampWeight - item.Key;
                takeoffMoment = rampMoment - item.Value;
                takeofCG = (takeoffMoment / takeoffWeight) * 100;

                Takeoff_Weight.Text = (takeoffWeight).ToString("0.00");
                Takeoff_Moment.Text = (takeoffMoment).ToString("0.00");
                Takeoff_CG.Text = $"Takeoff Center of Gravity: {takeofCG.ToString("0.0")}";
            }
        }

        foreach (var item in FuelTank)
        {
            if (fuelToDestination == item.Key)
            {
                landingWeight = takeoffWeight - item.Key;
                landingMoment = takeoffMoment - item.Value;
                landingCG = (landingMoment / landingWeight) * 100;

                Landing_Weight.Text = (landingWeight).ToString("0.00");
                Landing_Moment.Text = (landingMoment).ToString("0.00");
                Landing_CG.Text = $"Landing Center of Gravity: {(landingCG).ToString("0.0")}";
            }
        }

        Chart.BindingContext = null;
        WeightAndBalanceData.SetTaxiWeight(rampWeight, rampCG);
        WeightAndBalanceData.SetTkofWeight(takeoffWeight, takeofCG);
        WeightAndBalanceData.SetLandingWeight(landingWeight, landingCG);
        Chart.BindingContext = WeightAndBalanceData;

    }
}