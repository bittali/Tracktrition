using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class UserDataTests
    {

        private UserDataLoaderMock usersMock = new UserDataLoaderMock();
        List<UserData> users = new List<UserData>();
        UserData userMock;

        [SetUp]
        public void Setup()
        {
            users = usersMock.ReadUserDataFromFile();
            userMock = users[0];
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