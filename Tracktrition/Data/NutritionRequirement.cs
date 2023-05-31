namespace Tracktrition.Data;

public class NutritionRequirement : INutritionFacts
{
    public int calories { get; set; }
    public double fat { get; set; }
    public double protein { get; set; }
    public double carbs { get; set; }

    public NutritionRequirement(UserData user)
    {
        this.calories = CaloriesCalculator.CalculateCalories(user);
        this.fat = FatCalculator.CalculateFat(user, this.calories);
        this.protein = ProteinCalculator.CalculateProtein(user, this.calories);
        this.carbs = CarbsCalculator.CalculateCarbs(this.calories);
    }

    public static double CalcBMR (UserData user) {
        //BMR = Basal Metabolic Rate -> Täglicher Grundbedarf Kalorien
        if (user.sex == 'f') {
            return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) - 161;
        }
        return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) + 5;
    }
}
