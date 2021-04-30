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
using System.Windows.Input;

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
            ClearGraphic();
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
                Stopwatch sw2 = new Stopwatch();
                double time;


                switch (cmbChooseWay.SelectedIndex)
                {
                    case 0:
                        {
                           

                            ICalculator calculator = GetCalculator();
                            long n = 100000;

                            sw2.Start();
                            do
                            {
                                sw.Start();
                                double result = calculator.Calculate(a, b, n, x => 7 * x - Math.Log(7 * x) + 8);
                                sw.Stop();

                                DrawGraph(n, sw.ElapsedMilliseconds);
                                tbResult.Text = Convert.ToString(result);

                                sw.Reset();
                                n += 100000;
                            } while (n <= 1000000);
                            sw2.Stop();
                            time = sw.ElapsedMilliseconds/1000;
                            tbSequentialTime.Text=Convert.ToString(time) + " сек.";
                            sw2.Reset();

                            MyPlot.InvalidatePlot(true);
                        }
                        break;
                    case 1:
                        {
                            this.Cursor = Cursors.Wait;

                            ICalculator calculator = GetCalculator();
                            long n = 100000;

                            sw2.Start();
                            do
                            {
                                sw.Start();
                                double result = calculator.CalculateParallel(a, b, n, x => 7 * x - Math.Log(7 * x) + 8);
                                sw.Stop();

                                DrawGraph(n, sw.ElapsedMilliseconds);
                                tbResult.Text = Convert.ToString(result);
                                

                                sw.Reset();
                                n += 100000;
                            } while (n <= 1000000);
                            sw2.Stop();
                            time = sw2.ElapsedMilliseconds/1000;
                            tbParallelTime.Text=Convert.ToString(time)+" сек.";
                            MyPlot.InvalidatePlot(true);
                            this.Cursor = Cursors.Arrow;
                        }
                        break;
                    default: { } break;
                }


            }
        }

        private void DrawGraph(long x, double y)
        {
            MainViewModel model = DataContext as MainViewModel;

            DataPoint point = new DataPoint(x, y);
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
                case 0: return new RectangleCalculator(); 
                case 1: return new TrapCalculator(); 
                case 2: return new ParabolaCalculator(); 
                default: return new RectangleCalculator(); 
            }
        }

        private void btnClearGraphic_Click(object sender, RoutedEventArgs e)
        {
            ClearGraphic();
        }
    }
}
