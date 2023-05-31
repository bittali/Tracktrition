namespace Tracktrition.Main.Domain.Models;

internal class User
{
    public string name { get; private set; }
    public char sex { get; private set; }
    public int age { get; set; }
    public double weight { get; set; }
    public int height { get; set; }
    public double bmi { get; private set; }
    public int activity { get; set; }

    public User(string name, char sex, int age, double weight, int height, int activity)
    {
        this.name = name;
        this.sex = sex;
        this.age = age;
        this.weight = weight;
        this.height = height;
        bmi = calcBmi(weight, height);
        this.activity = activity;
    }

    private double calcBmi(double weight, double height)
    {
        return weight / (height * height);
    }
}
