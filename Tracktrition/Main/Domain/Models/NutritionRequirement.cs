namespace Tracktrition.Main.Domain.Models;

class NutritionRequirement : INutritionFacts
{
    public int calories { get; set; }
    public double fat { get; set; }
    public double protein { get; set; }
    public double carbs { get; set; }

    public NutritionRequirement(User user)
    {
        calories = (int)calcCalorieNeed(user);
        fat = calcFatNeed(user);
        protein = calcProteinNeed(user);
        carbs = calcCarbsNeed(user);
    }

    private double calcCarbsNeed(User user)
    {
        //45-65% of total cals independant of age
        return calories * 0.53 / 4;
    }

    private double calcFatNeed(User user)
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

        return calories * partFat / 9;
    }

    private double calcProteinNeed(User user)
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
        return calories * partProtein / 4;
    }

    // Calculations https://www.thecalculatorsite.com/articles/health/bmr-formula.php


    private double calcBMR(User user)
    {
        //BMR = Basal Metabolic Rate -> Täglicher Grundbedarf Kalorien
        if (user.sex == 'f')
        {
            return 10 * user.weight + 6.25 * user.height - 5 * user.age - 161;
        }
        return 10 * user.weight + 6.25 * user.height - 5 * user.age + 5;
    }

    private double calcCalorieNeed(User user)
    {
        double bmr = calcBMR(user);
        switch (user.activity)
        {
            case 1: //sedentary (little or no exercise)
                return bmr * 1.2;
            case 2: //lightly active (light exercise or sports 1-3 days/week)
                return bmr * 1.375;
            case 3: //moderately active (moderate exercise 3-5 days/week)
                return bmr * 1.55;
            case 4: //very active (hard exercise 6-7 days/week)
                return bmr * 1.725;
            case 5: //super active (very hard exercise and a physical job)
                return bmr * 1.9;
        }
        return 0;
    }
}
