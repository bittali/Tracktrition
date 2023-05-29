namespace Tracktrition.Data;

public class DailyIntake : INutritionFacts
{
    public DateTime date;
    public int calories { get; set; }
    public double carbs { get; set; }
    public double protein { get; set; }
    public double fat { get; set; }
    private List<Intake> dayIntake;

    public DailyIntake(DateTime date) {
        this.date = date;
        this.calories = 0;
        this.carbs = 0.0;
        this.protein = 0.0;
        this.fat = 0.0;
        this.dayIntake = new List<Intake>();
    }

    public void addIntake(double amount, Food food) {
        if (amount > 0)
        {
            Intake intake = new Intake(date, amount, food);

            this.dayIntake.Add(intake);

            calcDailyIntake(intake);
        }
    }

    private void calcDailyIntake(Intake intake) {
        this.calories += intake.calories;
        this.carbs += intake.carbs;
        this.protein += intake.protein;
        this.fat += intake.fat;
    }

    public void printDailyIntake()
    {
        Console.WriteLine("\nYour Intake today");
        Console.WriteLine("Date: " + date.ToString("yyyy-MM-dd"));
        Console.WriteLine("Calories: " + calories);
        Console.WriteLine("Carbs: " + carbs);
        Console.WriteLine("Protein: " + protein);
        Console.WriteLine("Fat: " + fat);
    }
}
