using System;
using System.Globalization;

namespace Tracktrition.Data
{
    public class ValidateCarbs
    {
        public static bool IsValid(string input, out double carbsValue)
        {
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out carbsValue))
            {
                if (carbsValue >= 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Carbs value must be a non-negative number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for carbs.");
            }

            return false;
        }
    }
}

