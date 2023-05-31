using System;

namespace Tracktrition.Data
{
    public class ValidateName
    {
        public static bool IsValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}

