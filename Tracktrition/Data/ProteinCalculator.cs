using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    public class ProteinCalculator : ICalculator
    {
        public static double CalculateProtein(UserData user, double calories)
        {
            double partProtein = .2;
            if (user.age > 3)
            { //10-30%
                partProtein = .2;
            }
            else if (user.age <= 3)
            { //5-20%
                partProtein = .12;
            }
            return Math.Round((calories * partProtein / 4), 1);
        }

        public double Calculate(UserData user, double calories) 
        { 
        return CalculateProtein(user, calories);
        }

    }

}
