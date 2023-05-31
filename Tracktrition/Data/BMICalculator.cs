using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    public static class BMICalculator
    {
        public static double CalculateBmi(double weight, double height)
        {
            var heightInMeters = height / 100;
            double calcBMI = weight / (heightInMeters * heightInMeters);
            return Math.Round(calcBMI, 1);
        }
    }
}
