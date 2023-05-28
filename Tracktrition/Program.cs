using Tracktrition.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

class Program
{

    const string fileName = "users.csv";

    static string loggedInUsername = null;

    static void Main()
    {

        UserData maxMuster = new UserData("Max Muster", 'm', 33, 75.0, 180, 1);

        NutritionRequirement needsMax = new NutritionRequirement(maxMuster);

        System.Console.WriteLine("The recommended daily nutritional need for {0} is: ", maxMuster.name);
        System.Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", needsMax.calories, needsMax.carbs.ToString("n2"), needsMax.protein.ToString("n2"), needsMax.fat.ToString("n2"));

        List<UserData> users = UserDataLoader.ReadUserDataFromFile();
        List<Food> foods = FoodLoader.ReadFoodFromFile();

        if (!Login(users))
        {
            users.Add(CreateUser());
        }

        // TBA
        // LOAD INTAKE DATA HERE 

        while (true)
        {
            Console.WriteLine("1. Add Intake");
            Console.WriteLine("2. View todays Intake");
            Console.WriteLine("3. View available Foods");
            Console.WriteLine("4. TBA");
            Console.WriteLine("5. TBA");
            Console.WriteLine("6. Logout");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // AddIntake();
                    break;
                case "2":
                    // ViewTodaysIntake();
                    break;
                case "3":
                    // ViewFoods();
                    break;
                case "4":
                    // ViewNutritionTracker();
                    break;
                case "5":
                    // ViewNutritionTracker();
                    break;
                case "6":
                    Console.WriteLine($"Logging out {loggedInUsername}...");
                    UserDataLoader.SaveUserDataToFile(users);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static bool Login(List<UserData> users)
    {
        Console.Write("Enter your name: ");
        string username = Console.ReadLine();

        foreach (UserData user in users)
        {
            if (user.name == username)
            {
                Console.WriteLine($"Welcome, {username}!");
                loggedInUsername = username;
                return true; // Name found in the list
            }
        }
        return false; // Name not found in the list
    }

    private static UserData CreateUser()
    {
        Console.WriteLine("This user does not exist");
        Console.WriteLine("Please provide following information");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your sex: ");
        char sex = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your weight: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height: ");
        int height = int.Parse(Console.ReadLine());

        Console.Write("Enter your activity: ");
        int activity = int.Parse(Console.ReadLine());

        UserData user = new UserData(name, sex, age, weight, height, activity);

        loggedInUsername = name;

        return user;

    }

    static void AddFoodItem()
    {
        //TBA
    }

    static void ViewNutritionTracker()
    {
        //TBA
    }

}