namespace Tracktrition.Data;

public class NutritionRequirement : INutritionFacts
{
    public int calories { get; set; }
    public double fat { get; set; }
    public double protein { get; set; }
    public double carbs { get; set; }

    private static readonly IEnumerable<ICalculator> Calculators = new List<ICalculator>
    {
        new CaloriesCalculator(),
        new FatCalculator(),
        new ProteinCalculator(),
        new CarbsCalculator()
    };
    public NutritionRequirement(UserData user)
    {
        List<double> Results = RunCalculators(user);
        this.calories = (int) Results[0];
        this.fat = Results[1];
        this.protein = Results[2];
        this.carbs = Results[3];
    }

    public List<double> RunCalculators(UserData user)
    {
        List<double> results = new List<double>();
        int calories = 0;
        bool isFirstIteration = true;

        foreach (var calculator in Calculators)
        {
            if (isFirstIteration)
            {
                double result = calculator.Calculate(user, 0);
                results.Add(result);
                calories = (int)results[0];
                isFirstIteration = false;
            }
            else
            {
                double result = calculator.Calculate(user, calories);
                results.Add(result);
            }
        }

        return results;
    }

    public static double CalcBMR (UserData user) {
        //BMR = Basal Metabolic Rate -> Täglicher Grundbedarf Kalorien
        if (user.sex == 'f') {
            return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) - 161;
        }
        return (10 * user.weight) + (6.25 * user.height) - (5 * user.age) + 5;
    }
}
