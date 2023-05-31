using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class DailyIntakeTests
    {
        private DateTime _todaysDateFake;
        private DailyIntake _dailyIntake;
        private FoodLoaderMock foodLoaderMock = new FoodLoaderMock();
        private Food testFood;

        [SetUp]
        public void Setup()
        {
            _todaysDateFake = new DateTime(2023, 01, 01);
            _dailyIntake = new DailyIntake(_todaysDateFake);
            testFood = foodLoaderMock.ReadFoodFromFile()[0];
        }

        [Test]
        public void addIntake_Test()
        {
            var amount = 200;
            _dailyIntake.addIntake(amount, testFood);

            Assert.That(_dailyIntake.dayIntake, Has.Count.EqualTo(1));
            Assert.That(_dailyIntake.calories, Is.EqualTo(600));
            Assert.That(_dailyIntake.fat, Is.EqualTo(20));
            Assert.That(_dailyIntake.protein, Is.EqualTo(40));
            Assert.That(_dailyIntake.carbs, Is.EqualTo(60));
        }
    }
}