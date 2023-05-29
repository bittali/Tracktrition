namespace Tracktrition.Data;

using System;
using System.Collections.Generic;
using System.IO;

public class UserDataLoader
{
    private const string UserDataFileName = "users.csv";

    public static List<UserData> ReadUserDataFromFile()
    {
        List<UserData> users = new List<UserData>();

        if (!File.Exists(UserDataFileName))
        {
            File.Create(UserDataFileName).Close(); // Create the file if it doesn't exist
        }

        using (StreamReader reader = new StreamReader(UserDataFileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line); // DEBUGGING
                string[] userData = line.Split(',');

                if (userData.Length == 6)
                {
                    UserData user = new UserData(
                        userData[0],
                        userData[1][0],
                        int.Parse(userData[2]),
                        double.Parse(userData[3]),
                        int.Parse(userData[4]),
                        int.Parse(userData[5])
                    );
                    users.Add(user);
                }
            }
        }

        return users;
    }

    public static bool SaveUserDataToFile(List<UserData> users)
    {
        using (StreamWriter writer = new StreamWriter(UserDataFileName))
        {
            foreach (UserData user in users)
            {
                string line = $"{user.name},{user.sex},{user.age},{user.weight},{user.height},{user.bmi},{user.activity}";
                writer.WriteLine(line);
            }
        }

        return true;
    }
}
