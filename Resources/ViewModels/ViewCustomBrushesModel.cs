using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewCustomBrushesModel
    {
        public CustomBrushesModel LineChart { get; set; }

        public ViewCustomBrushesModel()
        {
            LineChart = new();
            AddColors();
        }

        public void AddColors()
        {
            LineChart.CustomBrushes = new()
            {
            new SolidColorBrush(Color.FromHex("#1A000000")),
            new SolidColorBrush(Color.FromHex("#AE2012")),
            new SolidColorBrush(Color.FromHex("#CA6702")),
            new SolidColorBrush(Color.FromHex("#0A9396")),
            new SolidColorBrush(Color.FromHex("#0A9396")),
            new SolidColorBrush(Color.FromHex("#005F73")),
            new SolidColorBrush(Color.FromHex("#AE2012")),
            new SolidColorBrush(Color.FromHex("#CA6702")),
            };
        }

        public void AddColors(Brush newBrush)
        {
            LineChart.CustomBrushes.Add(newBrush);
        }

        public List<Brush> GetBrushes()
        {
            return LineChart.CustomBrushes;
        }
    }
}
