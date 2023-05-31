using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracktrition.Data;

public static class CarbsCalculator
{
    public static double CalculateCarbs(double calories)
    {

            //45-65% of total cals independant of age
            return calories * 0.53 / 4;

        // Calculations https://www.thecalculatorsite.com/articles/health/bmr-formula.php
    }
}
