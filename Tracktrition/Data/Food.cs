using System.Globalization;
using System.Xml.Linq;

namespace Tracktrition.Data;

public class Food : INutritionFacts
{
    public string name;
    public int calories { get; set; }
    public double fat { get; set; }
    public double protein { get; set; }
    public double carbs { get; set; }

    public Food(string name, int calories, double fat, double protein, double carbs)
    {
        this.name = name;
        this.calories = calories;
        this.fat = fat;
        this.protein = protein;
        this.carbs = carbs;
    }

    public void updateFood() {

        Console.Write("Enter the new name of the food: ");
        string? inputName = Console.ReadLine();

        while (string.IsNullOrEmpty(inputName))
        {
            Console.WriteLine("Invalid input. Please enter a valid name for the food.");
            Console.Write("Enter the name of the food: ");
            inputName = Console.ReadLine();
        }

        name = inputName;

        bool validInput = false;
        while (!validInput)
        {
            Console.Write("Enter the new number of calories: ");
            if (int.TryParse(Console.ReadLine(), out int caloriesValue))
            {
                calories = caloriesValue;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for calories.");
            }
        }

        validInput = false;
        while (!validInput)
        {
            Console.Write("Enter the new amount of fat: ");
            if (double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double fatValue))
            {
                fat = fatValue;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for fat.");
            }
        }

        validInput = false;
        while (!validInput)
        {
            Console.Write("Enter the new amount of protein: ");
            if (double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double proteinValue))
            {
                protein = proteinValue;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for protein.");
            }
        }

        validInput = false;
        while (!validInput)
        {
            Console.Write("Enter the new amount of carbs: ");
            if (double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double carbsValue))
            {
                carbs = carbsValue;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number for carbs.");
            }
        }
    }

    internal void PrintFacts()
    {
        Console.WriteLine(this.name + " ({0}g calories, {1}g fat, {2}g protein, {3}g carbs)", this.calories, this.fat, this.protein, this.carbs);
    }
}
