using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracktrition.Data
{
    class NutritionFacts
    {
        int calories { get; set; }
        double fat { get; set; }
        double protein { get; set; }
        double carbs { get; set; }
        
        public NutritionFacts(int calories, double fat, double protein, double carbs)
        {
            this.calories = calories;
            this.fat = fat;
            this.protein = protein;
            this.carbs = carbs;
        }
    }
}
