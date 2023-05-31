using Tracktrition.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Globalization;

class Program
{
    static UserData? currentUser;

    static readonly DateTime todaysDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"));

    static void Main()
    {

        List<UserData> users = UserDataLoader.ReadUserDataFromFile();
        List<Food> foods = FoodLoader.ReadFoodFromFile();

        if (!Login(users))
        {
            users.Add(CreateUser());
        }

        // LOAD INTAKE DATA HERE 
        List<DailyIntake> dailyUserIntakes = LoadIntake(currentUser.name);

        while (true)
        {
            Console.WriteLine("1. Add Intake");
            Console.WriteLine("2. View todays Intake");
            Console.WriteLine("3. View your recommended nutritional need");
            Console.WriteLine("4. View available Foods");
            Console.WriteLine("5. Add Food");
            Console.WriteLine("6. Change your data");
            Console.WriteLine("7. Logout");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddIntake(foods, dailyUserIntakes);
                    break;
                case "2":
                    ViewTodaysIntake(dailyUserIntakes);
                    break;
                case "3":
                    ViewNutritionNeed();
                    break;
                case "4":
                    ViewFoods(foods);
                    break;
                case "5":
                    foods = AddFoodItem(foods);
                    break;
                case "6":
                    ChangeUserData();
                    break;
                case "7":
                    Logout(users, foods, dailyUserIntakes);                   
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AddIntake(List<Food> foods, List<DailyIntake> dailyUserIntakes)
    {
        Console.Write("Enter your Intake Food: ");
        string foodname = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(foodname))
        {
            Console.WriteLine("Invalid input. Please enter a valid food name.");
            Console.Write("Enter your Intake Food: ");
            foodname = Console.ReadLine();
        }

        if (!CheckAndUpdateFood(foods, foodname))
        {
            Console.WriteLine("This Food does not exist. Please add it to the Database.");
            AddFoodItem(foods);
        }

        Food food = GetFoodFromName(foods, foodname);

        bool validAmount = false;
        int amount = 0;

        while (!validAmount)
        {
            Console.Write("Enter your Intake Amount: ");
            string input = Console.ReadLine();

            validAmount = int.TryParse(input, out amount);

            if (!validAmount)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer amount.");
            }
        }

        DailyIntake todaysIntake = DailyIntakeCheckAndUpdateToday(dailyUserIntakes);

        todaysIntake.addIntake(amount, food);

    }

    private static Food GetFoodFromName(List<Food> foods, string? foodName)
    {
        if (foods is null)
        {
            throw new ArgumentNullException(nameof(foods), "Foods list cannot be null.");
        }

        if (foods.Count == 0)
        {
            throw new ArgumentException("Foods list cannot be empty.", nameof(foods));
        }

        if (foodName is null)
        {
            throw new ArgumentNullException(nameof(foodName), "Food name cannot be null.");
        }


        Food? foundFood = foods.FirstOrDefault(food => food.name == foodName);
        if (foundFood is null)
        {
            throw new InvalidOperationException($"No food item found with the name '{foodName}'.");
        }

        return foundFood;
    }

    private static bool CheckAndUpdateFood(List<Food> foods, string? foodname)
    {
        foreach (Food food in foods)
        {

            if (food.name == foodname)
            {
                return true; // Name found in the list
            }
        }
        return false; // Name not found in the list
    }

    private static void Logout(List<UserData> users, List<Food> foods, List<DailyIntake> dailyUserIntakes)
    {
        Console.WriteLine($"Logging out {currentUser.name}...");
        UserDataLoader.SaveUserDataToFile(users);
        FoodLoader.SaveFoodsToFile(foods);
        DailyIntakeLoader.SaveDailyIntakeToFile(dailyUserIntakes, currentUser.name);
    }

    private static void ViewFoods(List<Food> foods)
    {
        foreach (Food food in foods)
        {
            Console.WriteLine(food.name + " ({0}g calories, {1}g fat, {2}g protein, {3}g carbs)", food.calories, food.fat, food.protein, food.carbs);
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
        currentUser.age = ReadNonEmptyInt();

        Console.Write("Enter your weight: ");
        currentUser.weight = ReadNonEmptyDouble();

        Console.Write("Enter your height: ");
        currentUser.height = ReadNonEmptyInt();

        Console.WriteLine("Activity Levels:");
        Console.WriteLine("1: Sedentary (little or no exercise)");
        Console.WriteLine("2: Lightly active (light exercise or sports 1-3 days/week)");
        Console.WriteLine("3: Moderately active (moderate exercise 3-5 days/week)");
        Console.WriteLine("4: Very active (hard exercise 6-7 days/week)");
        Console.WriteLine("5: Super active (very hard exercise and a physical job)");

        Console.Write("Enter the activity level (1-5): ");
        currentUser.activity = ReadNonEmptyInt();

    }

    private static void ViewNutritionNeed()
    {
        NutritionRequirement currentUserNeeds = new NutritionRequirement(currentUser);

        Console.WriteLine("The recommended daily nutritional need for {0} is: ", currentUser.name);
        Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", currentUserNeeds.calories, 
            currentUserNeeds.carbs.ToString("n2"), currentUserNeeds.protein.ToString("n2"), currentUserNeeds.fat.ToString("n2"));

    }

    private static List<DailyIntake> LoadIntake(string activeUser)
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
        string name = ReadNonEmptyLine();

        Console.Write("Enter your sex (m/f): ");
        string input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input) || input.Length > 1 || (input[0] != 'm' && input[0] != 'f'))
        {
            Console.WriteLine("Invalid input. Please enter 'm' for male or 'f' for female.");
            Console.Write("Enter your sex (m/f): ");
            input = Console.ReadLine();
        }

        char sex = input[0];

        Console.Write("Enter your age: ");
        int age = ReadNonEmptyInt();

        Console.Write("Enter your weight: ");
        double weight = ReadNonEmptyDouble();

        Console.Write("Enter your height: ");
        int height = ReadNonEmptyInt();

        Console.WriteLine("Activity Levels:");
        Console.WriteLine("1: Sedentary (little or no exercise)");
        Console.WriteLine("2: Lightly active (light exercise or sports 1-3 days/week)");
        Console.WriteLine("3: Moderately active (moderate exercise 3-5 days/week)");
        Console.WriteLine("4: Very active (hard exercise 6-7 days/week)");
        Console.WriteLine("5: Super active (very hard exercise and a physical job)");

        Console.Write("Enter the activity level (1-5): ");
        int activity = ReadNonEmptyInt();

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

    static List<Food> AddFoodItem(List<Food> foods)
    {
        Console.WriteLine("\nEnter the name of the food:");
        string name = ReadNonEmptyLine();

        Console.WriteLine("Enter the number of calories in 100g:");
        int calories = ReadNonEmptyInt();

        Console.WriteLine("Enter the amount of fat in 100g:");
        double fat = ReadNonEmptyDouble();

        Console.WriteLine("Enter the amount of protein in 100g:");
        double protein = ReadNonEmptyDouble();

        Console.WriteLine("Enter the amount of carbs in 100g:");
        double carbs = ReadNonEmptyDouble();

        Food food = new Food(name, calories, fat, protein, carbs);
        foods.Add(food);
        return foods;
    }

    // Function to read a non-empty string line
    static string ReadNonEmptyLine()
    {
        string input = "";
        while (string.IsNullOrWhiteSpace(input))
        {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty value.");
            }
        }
        return input;
    }

    // Function to read a non-empty integer value
    static int ReadNonEmptyInt()
    {
        int value = 0;
        bool validInput = false;
        while (!validInput)
        {
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out value);
            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer value.");
            }
        }
        return value;
    }

    // Function to read a non-empty double value with dot as decimal separator
    static double ReadNonEmptyDouble()
    {
        double value = 0.0;
        bool validInput = false;
        while (!validInput)
        {
            string input = Console.ReadLine();
            validInput = double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value.");
            }
        }
        return value;
    }


}