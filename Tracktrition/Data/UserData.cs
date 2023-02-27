
using Tracktrition.Data;

namespace Tracktrition.User
{
    internal class UserData
    {
        public string name { get; private set; }
        public char sex { get; private set; }
        public int age { get; set; }
        public double weight { get; set; }
        public int height { get; set; }
        public double bmi { get; private set; }
        public int activity { get; set; }

        public UserData(string name, char sex, int age, double weight, int height, int activity)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.bmi = weight / (height*height);
            this.activity = activity;
        }
    }
}
