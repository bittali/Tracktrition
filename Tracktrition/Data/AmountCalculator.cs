using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    public static class AmountCalculator
    {
        public static double CalculatePerAmount(double data, double amount)
        {
            double factor = amount * .01;
            return data * factor;
        }
    }
}
