using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace Integral_solution
{
    class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Graphic 7x - ln(7x) + 8";
            this.Points = new ObservableCollection<DataPoint> { };              
        }
        
        public string Title { get; private set; }
        public ObservableCollection<DataPoint> Points { get; private set; }
    }
}
