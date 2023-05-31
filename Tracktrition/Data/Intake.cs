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
        this.calories = (int)AmountCalculator.CalculatePerAmount(food.calories, amount);
        this.carbs = AmountCalculator.CalculatePerAmount(food.carbs, amount);
        this.protein = AmountCalculator.CalculatePerAmount(food.protein, amount);
        this.fat = AmountCalculator.CalculatePerAmount(food.fat, amount);
    }
}
