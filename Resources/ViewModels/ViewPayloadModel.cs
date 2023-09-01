using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewPayloadModel
    {
        public PayloadModel PayloadData { get; set; }
        public FuelModel FuelTank { get; set; }
        public ObservableCollection<FuelModel> FuelWeight { get; set; }
        public int[] StandardWeights { get; set; }

        public ViewPayloadModel()
        {
            PayloadData = new();
            FuelWeight = new();
            FuelTank = new();
            PopulatePayloadArms();
            PopulateFuelWeight();
            PopulateStandards();
        }

        private void PopulatePayloadArms()
        {

            PayloadData.FieldsAndArms = new Dictionary<string, double>()
            {
                { "Pilot (PIC)",131.0 },
                { "Pilot (SIC)", 131.0 },
                { "Seat 10 (SFS)", 174.2 },
                { "Seat 3", 202.5 },
                { "Seat 4", 202.5},
                { "Seat 5", 260.5 },
                { "Seat 6", 260.5 },
                { "Seat 7", 295.5 },
                { "Seat 8", 295.5 },
                { "Seat 9 LH Belted Toilet", 322.5 },
                { "Nose Baggage", 74.0 },
                { "Charts", 150.9 },
                { "LHF Evaporator Cabinet", 156.3 },
                { "RH Slimline Refreshment Center", 157.2 },
                { "LH Aft Vanity", 334.9 },
                { "Tailcone Baggage", 414.6 }
            };

        }

        public Dictionary<string, double> GetPayloadData()
        {
            return PayloadData.FieldsAndArms;
        }

        private void PopulateFuelWeight()
        {
            FuelTank.FuelTank = new Dictionary<int, double>()
            {
                { 100, 323.47 },
                { 200, 618.02 },
                { 300, 958.44 },
                { 400, 1273.08 },
                { 600, 1586.45 },
                { 500, 1898.76 },
                { 700, 2210.11 },
                { 800, 2520.64},
                { 900, 2830.77 },
                { 1000, 3140.40 },
                { 1100, 3449.71 },
                { 1200, 3759.36 },
                { 1300, 4068.74},
                { 1400, 4378.08},
                { 1500, 4687.35},
                { 1600, 4996.32 },
                { 1700, 5305.36 },
                { 1800, 5614.02 },
                { 1900, 5922.87 },
                { 2000, 6231.40 },
                { 2100, 6539.82 },
                { 2200, 6847.94 },
                { 2300, 7155.99 },
                { 2400, 7463.76 },
                { 2500, 7771.75},
                { 2600, 8079.76},
                { 2700, 8388.09},
                { 2800, 8696.24},
                { 2900, 9005.37},
                { 3000, 9314.40},
                { 3100, 9624.26},
                { 3200, 9934.08},
                { 3300, 10244.52},
                { 3400, 10554.62},
                { 3500, 10864.7},
                { 3600, 11175.12},
                { 3700, 11485.17},
                { 3800, 11795.58},
                { 3900, 12105.60},
                { 4000, 12415.6},
                { 4100, 12725.17},
                { 4200, 13035.12},
                { 4300, 13344.62},
                { 4400, 13654.08},
                { 4500, 13963.50},
                { 4600, 14272.88},
                { 4700, 14581.75},
                { 4710, 14612.81},
            };

            foreach(var weight in FuelTank.FuelTank)
            {
                FuelWeight.Add(new FuelModel()
                {
                    FuelWeight = weight.Key,
                });
            }    
        }

        public Dictionary<int, double> GetFuelTank()
        {
            return FuelTank.FuelTank;
        }

        private void PopulateStandards()
        {
            StandardWeights = new int[]
            {
                200,
                200,
                0,
                0,
                0,
                170,
                220,
                160,
                0,
                25,
                30,
                5,
                5,
                15,
                10,
                50,
            };
        }

        public int[] GetStandards()
        {
            return StandardWeights;
        }

    }
}
