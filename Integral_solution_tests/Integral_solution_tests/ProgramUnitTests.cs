using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculateLibrary;


namespace Integral_solution_tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TrapCalculator_is_working_right()
        {
            double expected= 35234.337;
            int a = 1,
                b = 100,
                n = 1000;
            TrapCalculator trapCalculator = new TrapCalculator();
            Func<double, double> f = x => 7 * x - Math.Log(7 * x) + 8;
            double real_value=trapCalculator.Calculate(a, b, n, f);
            Assert.AreEqual(expected, real_value, 0.01);

        }

        [TestMethod]
        public void RectangleCalculator_is_working_right()
        {
            double expected = 35234.337;
            int a = 1,
                b = 100,
                n = 1000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => 7 * x - Math.Log(7 * x) + 8;
            double real_value = rectangleCalculator.Calculate(a, b, n, f);
            Assert.AreEqual(expected, real_value, 0.01);

        }

        [TestMethod]
        public void ParabolaCalculator_is_working_right()
        {
            double expected = 35234.337;
            int a = 1,
                b = 100,
                n = 1000;
            ParabolaCalculator parabolaCalculator = new ParabolaCalculator();
            Func<double, double> f = x => 7 * x - Math.Log(7 * x) + 8;
            double real_value = parabolaCalculator.Calculate(a, b, n, f);
            Assert.AreEqual(expected, real_value, 0.01);

        }

        [TestMethod]
        public void b_is_bigger_than_a()
        {
            
            bool condition =false;
            int a = 1,
                b = -100;
            if (b < a) condition = true;
            Assert.IsTrue(condition);

        }

        [TestMethod]
      
        public void calculatorsAreNotTheSame()
        {
            TrapCalculator trapCalculator = new TrapCalculator();
            ParabolaCalculator parabolaCalculator = new ParabolaCalculator();

            Assert.AreNotSame(trapCalculator, parabolaCalculator);
        }

    }
}
