namespace Tracktrition.Main.Domain.Models;

public class DailyIntake : INutritionFacts
{
    public DateTime date;
    public int calories { get; set; }
    public double carbs { get; set; }
    public double protein { get; set; }
    public double fat { get; set; }
    private List<Intake> dayIntake;

    public DailyIntake(DateTime date)
    {
        this.date = date;
        calories = 0;
        carbs = 0.0;
        protein = 0.0;
        fat = 0.0;
        dayIntake = new List<Intake>();
    }

    public void addIntake(DateTime date, double amount, Food food)
    {
        if (amount > 0)
        {
            Intake intake = new Intake(date, amount, food);

            dayIntake.Add(intake);

            calcDailyIntake(date, intake);
        }
    }

    private void calcDailyIntake(DateTime date, Intake intake)
    {
        calories += intake.calories;
        carbs += intake.carbs;
        protein += intake.protein;
        fat += intake.fat;
    }




}
