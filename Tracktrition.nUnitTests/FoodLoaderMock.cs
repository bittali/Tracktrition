using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class FoodLoaderMock : FoodLoader
    {
        new public List<Food> ReadFoodFromFile()
        {
            List<Food> foods = new List<Food>();
            foods.Add(new Food("test food", 300, 10, 20, 30));
            return foods;
        }
    }
}
