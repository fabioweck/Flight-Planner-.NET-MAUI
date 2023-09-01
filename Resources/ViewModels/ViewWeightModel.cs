using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewWeightModel
    {
        public List<WeightModel> EnvelopeLimits { get; set; }
        public List<WeightModel> TkofLimits { get; set; }
        public List<WeightModel> LandingLimits { get; set; }
        public List<WeightModel> ZeroFuelLimits { get; set; }
        public List<WeightModel> ZeroFuelWeight { get; set; }
        public List<WeightModel> TaxiWeight { get; set; }
        public List<WeightModel> TkofWeight { get; set; }
        public List<WeightModel> LandingWeight { get; set; }

        public ViewWeightModel()
        {

            EnvelopeLimits = new List<WeightModel>()
            {
                new WeightModel{ Weight = 9700, CenterOfGravity = 293.86},
                new WeightModel{ Weight = 14070, CenterOfGravity = 298.64},
                new WeightModel{ Weight = 14070, CenterOfGravity = 304.71},
                new WeightModel{ Weight = 13000, CenterOfGravity = 304.71},
                new WeightModel{ Weight = 8000, CenterOfGravity = 302.46},
                new WeightModel{ Weight = 8000, CenterOfGravity = 298.72},
                new WeightModel{ Weight = 9000, CenterOfGravity = 293.86},
                new WeightModel{ Weight = 9700, CenterOfGravity = 293.86}
            };

            TkofLimits = new List<WeightModel>()
            {
                new WeightModel { Weight = 13870, CenterOfGravity = 298.42},
                new WeightModel{ Weight = 13870, CenterOfGravity = 304.71}
            };

            LandingLimits = new List<WeightModel>()
            {
                new WeightModel { Weight = 12750, CenterOfGravity = 297.2},
                new WeightModel{ Weight = 12750, CenterOfGravity = 304.60}
            };

            ZeroFuelLimits = new List<WeightModel>()
            {
                new WeightModel { Weight = 10510, CenterOfGravity = 294.75},
                new WeightModel{ Weight = 10510, CenterOfGravity = 303.59}
            };

            ZeroFuelWeight = new();
        }

        public void SetZeroFuelWeight(int weight, double cg)
        {

            if(ZeroFuelWeight.Count == 0)
            {
                ZeroFuelWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });        
            }
            else
            {
                ZeroFuelWeight.Clear();
                ZeroFuelWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
            
        }

        public void SetZeroTaxiWeight(int weight, double cg)
        {

            if (TaxiWeight.Count == 0)
            {
                TaxiWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
            else
            {
                TaxiWeight.Clear();
                TaxiWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
        }

        public void SetZeroTkofWeight(int weight, double cg)
        {

            if (TkofWeight.Count == 0)
            {
                TkofWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
            else
            {
                TkofWeight.Clear();
                TkofWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
        }

        public void SetZeroLandingWeight(int weight, double cg)
        {

            if (LandingWeight.Count == 0)
            {
                LandingWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
            else
            {
                LandingWeight.Clear();
                LandingWeight.Add(new WeightModel { Weight = weight, CenterOfGravity = cg });
            }
        }


    }
}
