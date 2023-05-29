using System.Xml.Linq;

namespace Tracktrition.Data;

public class Food : INutritionFacts
{
    public string name;
    public int calories { get; set; }
    public double fat { get; set; }
    public double protein { get; set; }
    public double carbs { get; set; }

    public Food()
    {
        this.name = "Apple";
        this.calories = 52;
        this.fat = 0.17;
        this.protein = 0.26;
        this.carbs = 13.81;
    }

    public Food(string name, int calories, double fat, double protein, double carbs)
    {
        this.name = name;
        this.calories = calories;
        this.fat = fat;
        this.protein = protein;
        this.carbs = carbs;
    }

    public void addFood(string name, int calories, double protein, double fat, double carbs) {
        // add new food
    }

    public void updateFood(string name, int calories, double protein, double fat, double carbs) {
        // replace food with same name
    }

    public List<Food> getFoods() {
        List<Food> foods = new List<Food>();
        // get all foods from file of foods an add them to list
        return foods;
    }
    public Food getFacts() {
        Food food = new Food();
        //alternatively array of nutrition facts
        return food;
    }

}
