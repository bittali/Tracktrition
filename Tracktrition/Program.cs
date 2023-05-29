using Tracktrition.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

class Program
{

    const string fileName = "users.csv";

    static UserData currentUser = null;

    static DateTime todaysDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"));

    static void Main()
    {

        List<UserData> users = UserDataLoader.ReadUserDataFromFile();
        List<Food> foods = FoodLoader.ReadFoodFromFile();

        if (!Login(users))
        {
            users.Add(CreateUser());
        }

        // LOAD INTAKE DATA HERE 
        List<DailyIntake> dailyUserIntakes = loadIntake(currentUser.name);

        while (true)
        {
            Console.WriteLine("1. Add Intake");
            Console.WriteLine("2. View todays Intake");
            Console.WriteLine("3. View your recommended nutritional need");
            Console.WriteLine("4. View available Foods");
            Console.WriteLine("5. Change your data");
            Console.WriteLine("6. Logout");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // AddIntake();
                    break;
                case "2":
                    ViewTodaysIntake(dailyUserIntakes);
                    break;
                case "3":
                    ViewNutritionNeed();
                    break;
                case "4":
                    // ViewFoods();
                    break;
                case "5":
                    ChangeUserData();
                    break;
                case "6":
                    Console.WriteLine($"Logging out {currentUser.name}...");
                    UserDataLoader.SaveUserDataToFile(users);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void ViewTodaysIntake(List<DailyIntake> dailyUserIntakes)
    {
        DailyIntake todaysIntake = DailyIntakeCheckAndUpdateToday(dailyUserIntakes);

        todaysIntake.printDailyIntake();

    }

    private static void ChangeUserData()
    {

        currentUser.printData();

        Console.WriteLine("\nYou can change the following Data:");

        Console.Write("Enter your age: ");
        currentUser.age = int.Parse(Console.ReadLine());

        Console.Write("Enter your weight: ");
        currentUser.weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height: ");
        currentUser.height = int.Parse(Console.ReadLine());

        Console.WriteLine("Activity Levels:");
        Console.WriteLine("1: Sedentary (little or no exercise)");
        Console.WriteLine("2: Lightly active (light exercise or sports 1-3 days/week)");
        Console.WriteLine("3: Moderately active (moderate exercise 3-5 days/week)");
        Console.WriteLine("4: Very active (hard exercise 6-7 days/week)");
        Console.WriteLine("5: Super active (very hard exercise and a physical job)");

        Console.Write("Enter the activity level (1-5): ");
        currentUser.activity = int.Parse(Console.ReadLine());

    }

    private static void ViewNutritionNeed()
    {
        NutritionRequirement currentUserNeeds = new NutritionRequirement(currentUser);

        Console.WriteLine("The recommended daily nutritional need for {0} is: ", currentUser.name);
        Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", currentUserNeeds.calories, 
            currentUserNeeds.carbs.ToString("n2"), currentUserNeeds.protein.ToString("n2"), currentUserNeeds.fat.ToString("n2"));

    }

    private static List<DailyIntake> loadIntake(string activeUser)
    {
        List<DailyIntake> dailyIntakes = DailyIntakeLoader.ReadDailyIntakeFromFile(activeUser);

        return dailyIntakes;
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
                currentUser = user;
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

        Console.Write("Enter your sex (m/f): ");
        char sex = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your weight: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height: ");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Activity Levels:");
        Console.WriteLine("1: Sedentary (little or no exercise)");
        Console.WriteLine("2: Lightly active (light exercise or sports 1-3 days/week)");
        Console.WriteLine("3: Moderately active (moderate exercise 3-5 days/week)");
        Console.WriteLine("4: Very active (hard exercise 6-7 days/week)");
        Console.WriteLine("5: Super active (very hard exercise and a physical job)");

        Console.Write("Enter the activity level (1-5): ");
        int activity = int.Parse(Console.ReadLine());

        UserData user = new UserData(name, sex, age, weight, height, activity);

        currentUser = user;

        return user;

    }

    public static DailyIntake DailyIntakeCheckAndUpdateToday(List<DailyIntake> dailyUserIntakes)
    {
        DateTime todaysDate = DateTime.Today;
        var existingIntake = dailyUserIntakes.FirstOrDefault(item => item.date.Date == todaysDate);

        if (existingIntake != null)
        {
            return existingIntake;
        }

        var newIntake = new DailyIntake(todaysDate);
        dailyUserIntakes.Add(newIntake);
        return newIntake;
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