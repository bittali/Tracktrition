using Tracktrition.Data;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

class Program
{

    static Dictionary<string, int> nutritionTracker = new Dictionary<string, int>();

    const string fileName = "users.csv";

    static UserData loggedInUser = null;

    static void Main()
    {

        UserData maxMuster = new UserData("Max Muster", 'm', 33, 75.0, 180, 1);

        NutritionRequirement needsMax = new NutritionRequirement(maxMuster);

        System.Console.WriteLine("The recommended daily nutritional need for {0} is: ", maxMuster.name);
        System.Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", needsMax.calories, needsMax.carbs.ToString("n2"), needsMax.protein.ToString("n2"), needsMax.fat.ToString("n2"));

        List<UserData> users = ReadUsersFromFile(fileName);

        if (!Login(users))
        {
            users.Add(CreateUser());
        }

        while (true)
        {
            Console.WriteLine("1. Add food item");
            Console.WriteLine("2. View nutrition tracker");
            Console.WriteLine("3. Logout");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    ViewNutritionTracker();
                    break;
                case "3":
                    Console.WriteLine($"Logging out {loggedInUser}...");
                    SaveUsersToFile(users, fileName);
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

    public static List<UserData> ReadUsersFromFile(string fileName)
    {
        List<UserData> users = new List<UserData>();

        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close(); // Create the file if it doesn't exist
        }

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] userData = line.Split(',');

                if (userData.Length == 6)
                {
                    UserData user = new UserData(userData[0], userData[1][0], int.Parse(userData[2]), double.Parse(userData[3]), int.Parse(userData[4]), int.Parse(userData[5]));
                    users.Add(user);
                }
            }
        }

        return users;
    }

    public static void SaveUsersToFile(List<UserData> users, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (UserData user in users)
            {
                string line = $"{user.name},{user.sex},{user.age},{user.weight},{user.height},{user.activity}";
                writer.WriteLine(line);
            }
        }
    }

}