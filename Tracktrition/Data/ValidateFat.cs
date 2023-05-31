using System;
using System.Globalization;

namespace Tracktrition.Data
{
    public class ValidateFat
    {
        public static bool IsValid(string input, out double fatValue)
        {
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out fatValue))
            {
                if (fatValue >= 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Fat value must be a non-negative number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for fat.");
            }

            return false;
        }
    }
}