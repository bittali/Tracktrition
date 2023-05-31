
namespace Tracktrition.Data;

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;


public class UserData
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
        this.bmi = BMICalculator.CalculateBmi(weight, (double)height);
        this.activity = activity;
    }

    internal void PrintData()
    {
        Console.WriteLine("Your currently saved Data");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Sex: " + sex);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Weight: " + weight);
        Console.WriteLine("Height: " + height);
        Console.WriteLine("Activity: " + activity);
    }

    internal void printBMI() 
    { 
        Console.WriteLine("Your current BMI: " + bmi); 
    }
}
