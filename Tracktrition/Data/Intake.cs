namespace Tracktrition.Data;

public class Intake : INutritionFacts 
{
    public DateTime date;
    public double amount;
    public int calories { get; set; }
    public double carbs { get; set; }
    public double protein { get; set; }
    public double fat { get; set; }

    public Intake(DateTime date, double amount, Food food) {
        this.date = date;
        this.amount = amount;
        this.calories = (int)calcPerAmount(food.calories, amount);
        this.carbs = calcPerAmount(food.carbs, amount);
        this.protein = calcPerAmount(food.protein, amount);
        this.fat = calcPerAmount(food.fat, amount);
    }

    private static double calcPerAmount(double data, double amount) {
        double factor = amount * .01;
        return data * factor;
    }
}
