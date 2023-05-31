using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class UserDataTests
    {

        //private const string fileName = "users.csv";

        private UserData _currentUser { get; set; } = null!;

        //private DateTime todaysDateFake;

        [SetUp]
        public void Setup()
        {
            //todaysDateFake = new DateTime(2023, 01, 01);
            _currentUser = new UserData("Max", 'm', 30, 70, 176, 2);
        }

        [Test]
        public void calcBmi_EqualTest()
        {
            var weight = 70;
            var height = 176;

            var bmi = BMICalculator.CalculateBmi(weight, height);

            Assert.That(bmi, Is.EqualTo(22.6));
        }
    }
}