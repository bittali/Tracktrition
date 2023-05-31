using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class DailyIntakeTests
    {

        //private const string fileName = "users.csv";

        private UserData _currentUser { get; set; } = null!;

        private DateTime _todaysDateFake;

        private Food food = null!;
        private DailyIntake _dailyIntake;

        [SetUp]
        public void Setup()
        {
            _todaysDateFake = new DateTime(2023, 01, 01);
            _currentUser = new UserData("Max", 'm', 30, 70, 176, 2);
            _dailyIntake = new DailyIntake(_todaysDateFake);
            food = new Food("test food", 300, 10, 20, 30);
        }

        [Test]
        public void addIntake_Test()
        {
            var amount = 200;
            _dailyIntake.addIntake(amount, food);

            var _intakes = _dailyIntake.dayIntake;

            Assert.That(_dailyIntake.dayIntake, Has.Count.EqualTo(1));
            Assert.That(_dailyIntake.calories, Is.EqualTo(600));
            Assert.That(_dailyIntake.fat, Is.EqualTo(20));
            Assert.That(_dailyIntake.protein, Is.EqualTo(40));
            Assert.That(_dailyIntake.carbs, Is.EqualTo(60));

        }
    }
}