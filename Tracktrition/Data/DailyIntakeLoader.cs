namespace Tracktrition.Data;

using System;
using System.Collections.Generic;
using System.IO;

public class DailyIntakeLoader
{
    private const string DailyIntakeFileName = "daily_intake.csv";

    public static List<DailyIntake> ReadDailyIntakeFromFile(string username)
    {
        string UserDailyIntakeFileName = username + "_" + DailyIntakeFileName;

        List<DailyIntake> dailyIntakes = new List<DailyIntake>();

        CheckForFile(UserDailyIntakeFileName);

        using (StreamReader reader = new StreamReader(UserDailyIntakeFileName))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] intakeData = line.Split(',');

                if (intakeData.Length == 5)
                {
                    DateTime date = DateTime.Parse(intakeData[0]);
                    int calories = int.Parse(intakeData[1]);
                    double carbs = double.Parse(intakeData[2]);
                    double protein = double.Parse(intakeData[3]);
                    double fat = double.Parse(intakeData[4]);

                    DailyIntake dailyIntake = new DailyIntake(date)
                    {
                        calories = calories,
                        carbs = carbs,
                        protein = protein,
                        fat = fat
                    };

                    dailyIntakes.Add(dailyIntake);
                }
            }
        }

        return dailyIntakes;
    }

    private static void CheckForFile(string userDailyIntakeFileName)
    {
        if (!File.Exists(userDailyIntakeFileName))
        {
            File.Create(userDailyIntakeFileName).Close(); // Create the file if it doesn't exist
        }
    }

    public static bool SaveDailyIntakeToFile(List<DailyIntake> dailyIntakes, string username)
    {
        string UserDailyIntakeFileName = username + "_" + DailyIntakeFileName;

        using (StreamWriter writer = new StreamWriter(UserDailyIntakeFileName))
        {
            foreach (DailyIntake dailyIntake in dailyIntakes)
            {
                string line = $"{dailyIntake.date},{dailyIntake.calories},{dailyIntake.carbs},{dailyIntake.protein},{dailyIntake.fat}";
                writer.WriteLine(line);
            }
        }

        return true;
    }
}

