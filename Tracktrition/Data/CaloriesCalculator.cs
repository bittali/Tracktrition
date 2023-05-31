using Tracktrition.Data;

public static class CaloriesCalculator
{
    public static double CalculateBMR(UserData user)
    {
        //BMR = Basal Metabolic Rate -> Täglicher Grundbedarf Kalorien
        if (user.sex == 'f')
        {
            return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) - 161;
        }
        return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) + 5;
    }
    public static int CalculateCalories(UserData user)
    {
        double bmr = CalculateBMR(user);
        switch (user.activity)
        {
            case 1: // sedentary (little or no exercise)
                return (int)(bmr * 1.2);
            case 2: // lightly active (light exercise or sports 1-3 days/week)
                return (int)(bmr * 1.375);
            case 3: // moderately active (moderate exercise 3-5 days/week)
                return (int)(bmr * 1.55);
            case 4: // very active (hard exercise 6-7 days/week)
                return (int)(bmr * 1.725);
            case 5: // super active (very hard exercise and a physical job)
                return (int)(bmr * 1.9);
            default:
                throw new InvalidOperationException("Invalid activity level specified.");
        }
    }
}
