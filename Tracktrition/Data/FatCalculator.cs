using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    public static class FatCalculator
    {
        public static double CalculateFat(UserData user, double calories)
        {
            double partFat = 0.3;

            if (user.age > 18)
            { //20-35%
                partFat = 0.27;
            }
            else if (user.age > 3 && user.age <= 18)
            { //25-35%
                partFat = 0.3;
            }
            else if (user.age <= 3)
            { //30-40%
                partFat = 0.35;
            }

            return Math.Round((calories * partFat / 9), 1);
        }
    }
}
