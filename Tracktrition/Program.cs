using Tracktrition.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Globalization;

class Program
{

    static void Main()
    {

        List<UserData> users = UserDataLoader.ReadUserDataFromFile();
        List<Food> foods = FoodLoader.ReadFoodFromFile();

        UserData? loggedInUser = Login(users);
        
        // If loggedInUser is NULL CreateUser() is executed
        UserData currentUser = loggedInUser ?? CreateUser();

        // LOAD INTAKE DATA HERE 
        List<DailyIntake> dailyUserIntakes = LoadIntake(currentUser.name);

        while (true)
        {
            Console.WriteLine("1. Add Intake");
            Console.WriteLine("2. View today's Intake");
            Console.WriteLine("3. View your recommended nutritional need");
            Console.WriteLine("4. View available Foods");
            Console.WriteLine("5. Add Food");
            Console.WriteLine("6. Update Food Data");
            Console.WriteLine("7. Change your data");
            Console.WriteLine("8. Logout");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddIntake(foods, dailyUserIntakes);
                    break;
                case "2":
                    ViewTodaysIntake(dailyUserIntakes);
                    break;
                case "3":
                    ViewNutritionNeed(currentUser);
                    break;
                case "4":
                    ViewFoods(foods);
                    break;
                case "5":
                    foods = AddFoodItem(foods);
                    break;
                case "6":
                    UpdateFoodData(foods);
                    break;
                case "7":
                    ChangeUserData(currentUser);
                    break;
                case "8":
                    Logout(users, foods, dailyUserIntakes, currentUser);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void UpdateFoodData(List<Food> foods)
    {
        Console.WriteLine("Available Foods:");
        foreach (var food in foods)
        {
            Console.WriteLine(food.name);
        }

        if (!foods.Any())
        {
            Console.WriteLine("No available foods. Please add foods to the database.");
            return;
        }

        Food foodToUpdate = GetFoodFromName(foods);
        if (foodToUpdate != null)
        {
            foodToUpdate.updateFood();
        }
        else
        {
            Console.WriteLine("Food not found.");
            throw new ArgumentNullException("Food name cannot be null.");
        }
    }


    private static void AddIntake(List<Food> foods, List<DailyIntake> dailyUserIntakes)
    {

        Food food = GetFoodFromName(foods);

        bool validAmount = false;
        int amount = 0;

        while (!validAmount)
        {
            Console.Write("Enter your Intake Amount: ");
            string? input = Console.ReadLine();

            validAmount = int.TryParse(input, out amount);

            if (!validAmount)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer amount.");
            }
        }

        DailyIntake todaysIntake = DailyIntakeCheckAndUpdateToday(dailyUserIntakes);

        todaysIntake.addIntake(amount, food);

    }

    private static Food GetFoodFromName(List<Food> foods)
    {
        if (foods is null)
        {
            throw new ArgumentNullException(nameof(foods), "Foods list cannot be null.");
        }

        if (foods.Count == 0)
        {
            throw new ArgumentException("Foods list cannot be empty.", nameof(foods));
        }

        Food? foundFood = null;
        while (foundFood is null)
        {
            Console.Write("Enter the name of the food: ");
            string? name = Console.ReadLine();

            foundFood = foods.FirstOrDefault(food => food.name == name);

            if (foundFood is null)
            {
                Console.WriteLine($"No food item found with the name '{name}'. Please enter a valid name.");
            }
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

    private static void Logout(List<UserData> users, List<Food> foods, List<DailyIntake> dailyUserIntakes, UserData currentUser)
    {
        Console.WriteLine($"Logging out {currentUser.name}...");
        UserDataLoader.SaveUserDataToFile(users);
        FoodLoader.SaveFoodsToFile(foods);
        DailyIntakeLoader.SaveDailyIntakeToFile(dailyUserIntakes, currentUser.name);
    }

    private static void ViewFoods(List<Food> foods)
    {
        if (foods.Count == 0)
        {
            Console.WriteLine("No foods available.");
            return;
        }

        foreach (Food food in foods)
        {
            food.PrintFacts();
        }
    }

    private static void ViewTodaysIntake(List<DailyIntake> dailyUserIntakes)
    {
        DailyIntake todaysIntake = DailyIntakeCheckAndUpdateToday(dailyUserIntakes);

        todaysIntake.printDailyIntake();

    }

    private static void ChangeUserData(UserData currentUser)
    {

        currentUser.PrintData();

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

    private static void ViewNutritionNeed(UserData currentUser)
    {
        NutritionRequirement currentUserNeeds = new (currentUser);

        Console.WriteLine("The recommended daily nutritional need for {0} is: ", currentUser.name);
        Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", currentUserNeeds.calories, 
            currentUserNeeds.carbs.ToString("n2"), currentUserNeeds.protein.ToString("n2"), currentUserNeeds.fat.ToString("n2"));

    }

    private static List<DailyIntake> LoadIntake(string activeUser)
    {
        List<DailyIntake> dailyIntakes = DailyIntakeLoader.ReadDailyIntakeFromFile(activeUser);

        return dailyIntakes;
    }

    static UserData? Login(List<UserData> users)
    {
        Console.Write("Enter your name: ");
        string username = ReadNonEmptyLine();

        foreach (UserData user in users)
        {
            if (user.name == username)
            {
                Console.WriteLine($"Welcome, {username}!");
                return user; // Return the user object
            }
        }
        return null; // User not found in the list
    }

    private static UserData CreateUser()
    {
        Console.WriteLine("This user does not exist");
        Console.WriteLine("Please provide following information");

        Console.Write("Enter your name: ");
        string name = ReadNonEmptyLine();

        Console.Write("Enter your sex (m/f): ");
        string? input = Console.ReadLine();

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

        UserData user = new(name, sex, age, weight, height, activity);

        return user;

    }

    public static DailyIntake DailyIntakeCheckAndUpdateToday(List<DailyIntake> dailyUserIntakes)
    {
        DateTime todaysDate = DateTime.Today;

        // Check if there is an existing intake for today's date
        var existingIntake = FindIntakeForToday(dailyUserIntakes, DateTime.Today);

        // If an existing intake is found, return it
        if (existingIntake != null)
        {
            return existingIntake;
        }

        // If no existing intake is found, create a new intake for today's date
        var newIntake = new DailyIntake(todaysDate);

        // Add the new intake to the list of daily user intakes
        dailyUserIntakes.Add(newIntake);

        // Return the newly created intake
        return newIntake;
    }

    static DailyIntake? FindIntakeForToday(List<DailyIntake> intakes, DateTime date)
    {
        foreach (var intake in intakes)
        {
            if (intake.date.Date == date.Date)
            {
                return intake;
            }
        }
        return null;
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

        Food food = new(name, calories, fat, protein, carbs);
        foods.Add(food);
        return foods;
    }

    // Function to read a non-empty string line
    static string ReadNonEmptyLine()
    {
        string? input = "";
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
            string? input = Console.ReadLine();
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
            string? input = Console.ReadLine();
            validInput = double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value.");
            }
        }
        return value;
    }


}