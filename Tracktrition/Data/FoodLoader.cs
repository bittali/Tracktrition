namespace Tracktrition.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FoodLoader
{

    const string FoodFileName = "foods.csv";

    public static List<Food> ReadFoodFromFile()
    {
        List<Food> users = new List<Food>();

        if (!File.Exists(FoodFileName))
        {
            File.Create(FoodFileName).Close(); // Create the file if it doesn't exist
        }

        using (StreamReader reader = new StreamReader(FoodFileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] userData = line.Split(',');

                if (userData.Length == 5)
                {
                    Food food = new Food(userData[0], int.Parse(userData[1]), double.Parse(userData[2]), double.Parse(userData[2]), double.Parse(userData[4]));
                    users.Add(food);
                }
            }
        }

        return users;
    }

    public static bool SaveFoodsToFile(List<Food> foods)
    {
        using (StreamWriter writer = new StreamWriter(FoodFileName))
        {
            foreach (Food food in foods)
            {
                string line = $"{food.name},{food.calories},{food.fat},{food.protein},{food.carbs}";
                writer.WriteLine(line);
            }
        }

        return true;

    }
}
