using Tracktrition.Data;

// See https://aka.ms/new-console-template for more information

UserData maxMuster = new UserData("Max Muster", 'm', 33, 75.0, 180, 1);

NutritionRequirement needsMax = new NutritionRequirement(maxMuster);

System.Console.WriteLine("The recommended daily nutritional need for {0} is: ", maxMuster.name);
System.Console.WriteLine("Calories: {0} \nCarbs: {1} g \nProtein: {2} g \nFat: {3} g \n", needsMax.calories, needsMax.carbs.ToString("n2"), needsMax.protein.ToString("n2"), needsMax.fat.ToString("n2"));
