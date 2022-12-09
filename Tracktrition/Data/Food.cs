using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    class Food
    {
        string name;
        int calories;
        double fat;
        double protein;
        double carbs;

        Food(string name, int calories, double fat, double protein, double carbs)
        {
            this.name = name;
            this.calories = calories;
            this.fat = fat;
            this.protein = protein; 
            this.carbs = carbs;
        }

    }
}
