namespace Tracktrition.Main.Domain.Models;

public class Intake : INutritionFacts
{
    public DateTime date;
    public double amount;
    public int calories { get; set; }
    public double carbs { get; set; }
    public double protein { get; set; }
    public double fat { get; set; }

    public Intake(DateTime date, double amount, Food food)
    {
        this.date = date;
        this.amount = amount;
        calories = (int)calcPerAmount(food.calories, amount);
        carbs = calcPerAmount(food.carbs, amount);
        protein = calcPerAmount(food.protein, amount);
        fat = calcPerAmount(food.fat, amount);
    }

    private static double calcPerAmount(double data, double amount)
    {
        double factor = amount * .1;
        return data * factor;
    }
}
