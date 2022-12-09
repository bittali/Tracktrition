using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.User
{
    internal class UserData
    {

        string name;
        char sex;
        int age;
        double weight;
        double height;
        double bmi;

        UserData(string name, double weight, double height)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            this.bmi = weight / (height*height);    
        }
    }
}
