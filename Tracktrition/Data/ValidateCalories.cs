using System;

namespace Tracktrition.Data
{
    public class ValidateCalories
    {
        public static bool IsValid(string input, out int caloriesValue)
        {
            if (int.TryParse(input, out caloriesValue) && caloriesValue >= 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative integer for calories.");
                return false;
            }
        }
    }
}

