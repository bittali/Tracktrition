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

    public void UpdateFood()
    {
        UpdateName();
        UpdateCalories();
        UpdateFat();
        UpdateProtein();
        UpdateCarbs();
    }

    private void UpdateName()
    {
        Console.Write("Enter the new name of the food: ");
        string? inputName = Console.ReadLine();

        while (!ValidateName.IsValid(inputName))
        {
            Console.WriteLine("Invalid input. Please enter a valid name for the food.");
            Console.Write("Enter the name of the food: ");
            inputName = Console.ReadLine();
        }

        this.name = inputName.Trim();
    }

    private void UpdateCalories()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Enter the new number of calories: ");
            string? input = Console.ReadLine();

            if (ValidateCalories.IsValid(input, out int caloriesValue))
            {
                this.calories = caloriesValue;
                validInput = true;
            }
        }
    }


    private void UpdateFat()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Enter the new amount of fat: ");
            string? input = Console.ReadLine();

            if (ValidateFat.IsValid(input, out double fatValue))
            {
                this.fat = fatValue;
                validInput = true;
            }
        }
    }


    private void UpdateProtein()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Enter the new amount of protein: ");
            string? input = Console.ReadLine();

            if (ValidateProtein.IsValid(input, out double proteinValue))
            {
                this.protein = proteinValue;
                validInput = true;
            }
        }
    }

    private void UpdateCarbs()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Enter the new amount of carbs: ");
            string? input = Console.ReadLine();

            if (ValidateCarbs.IsValid(input, out double carbsValue))
            {
                this.carbs = carbsValue;
                validInput = true;
            }
        }
    }


    internal void PrintFacts()
    {
        Console.WriteLine(this.name + " ({0}g calories, {1}g fat, {2}g protein, {3}g carbs)", this.calories, this.fat, this.protein, this.carbs);
    }
}
