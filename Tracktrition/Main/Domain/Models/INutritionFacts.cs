namespace Tracktrition.Main.Domain.Models
{
    interface INutritionFacts
    {
        int calories { get; set; }
        double fat { get; set; }
        double protein { get; set; }
        double carbs { get; set; }

    }
}
