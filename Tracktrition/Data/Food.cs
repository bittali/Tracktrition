using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    class Food : NutritionFacts
    {
        string name;

        public Food(string name, int calories, double fat, double protein, double carbs) : base(calories, fat, protein, carbs)
        {
            this.name = name;
        }

    }
}
