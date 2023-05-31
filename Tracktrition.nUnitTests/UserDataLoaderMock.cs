using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class UserDataLoaderMock : UserDataLoader
    {
        new public List<UserData> ReadUserDataFromFile()
        {
            List<UserData> users = new List<UserData>();
            users.Add(new UserData("Max", 'm', 30, 70, 176, 2));
            users.Add(new UserData("Lisa", 'f', 30, 55, 160, 3));
            users.Add(new UserData("Kindername", 'f', 8, 55, 160, 3));
            users.Add(new UserData("Babyname", 'f', 0, 55, 160, 3));
            users.Add(new UserData("Adult", 'f', 25, 55, 160, 3));
            users.Add(new UserData("Lisa1", 'f', 30, 55, 160, 1));
            users.Add(new UserData("Lisa2", 'f', 30, 55, 160, 2));
            users.Add(new UserData("Lisa3", 'f', 30, 55, 160, 3));
            users.Add(new UserData("Lisa4", 'f', 30, 55, 160, 4));
            users.Add(new UserData("Lisa5", 'f', 30, 55, 160, 5));
            return users;
        }
    }
}
