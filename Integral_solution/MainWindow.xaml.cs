using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CalculateLibrary;
using OxyPlot;
using OxyPlot.Series;


namespace Integral_solution
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            
        }





        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            Calculate();


        }



        private void Calculate()
        {

            if (Li.Text == "" || Hi.Text == "" || tbN.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                double a = Convert.ToDouble(Li.Text),
                b = Convert.ToDouble(Hi.Text);
               

                Stopwatch sw = new Stopwatch();

                ICalculator calculator = GetCalculator();
                long n = 100000;
               

                do
                {
                    sw.Start();
                    double result = calculator.Calculate(a, b, n, x => 7 * x - Math.Log(7 * x) + 8);
                    sw.Stop();

                    DrawGraph(n, sw.ElapsedMilliseconds);
                    tbResult.Text = Convert.ToString(result);
                    
                    sw.Reset();
                    n += 100000;
                } while (n<=1000000);

               MyPlot.InvalidatePlot(true);
            }
        }

        private void DrawGraph(long x, double y)
        {
            MainViewModel model = DataContext as MainViewModel;

                DataPoint point = new DataPoint(x,y);
                model.Points.Add(point);
            
        }

        private void ClearGraphic()
        {
            MainViewModel model = DataContext as MainViewModel;
            model.Points.Clear();
            MyPlot.InvalidatePlot(true);
        }

        private ICalculator GetCalculator()
        {
            switch (cmbChooseMethod.SelectedIndex)
            {
                case 0: return new RectangleCalculator(); break;
                case 1: return new TrapCalculator(); break;
                default: return new RectangleCalculator(); break;
            }
        }

        private void btnClearGraphic_Click(object sender, RoutedEventArgs e)
        {
            ClearGraphic();
        }
    }
}
