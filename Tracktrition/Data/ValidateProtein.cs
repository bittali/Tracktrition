using System;
using System.Globalization;

namespace Tracktrition.Data
{
    public class ValidateProtein
    {
        public static bool IsValid(string input, out double proteinValue)
        {
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out proteinValue))
            {
                if (proteinValue >= 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Protein value must be a non-negative number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for protein.");
            }

            return false;
        }
    }
}
