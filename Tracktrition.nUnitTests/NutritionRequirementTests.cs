using System.Runtime.CompilerServices;
using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class NutritionRequirementTests
    {

        private UserDataLoaderMock usersMock = new UserDataLoaderMock();
        List<UserData> users = new List<UserData>();
        private NutritionRequirement _nutriRequ0 { get; set; } = null!;
        private NutritionRequirement _nutriRequ1 { get; set; } = null!;
        private NutritionRequirement _nutriRequ2 { get; set; } = null!;
        private NutritionRequirement _nutriRequ3 { get; set; } = null!;
        private NutritionRequirement _nutriRequ4 { get; set; } = null!;


        [SetUp]
        public void Setup()
        {
            users = usersMock.ReadUserDataFromFile();
        }


        [Test]
        public void calcFatNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(users[3]);
            _nutriRequ1 = new NutritionRequirement(users[2]);
            _nutriRequ2 = new NutritionRequirement(users[4]);

            Assert.That(_nutriRequ0.fat, Is.EqualTo(83.7));
            Assert.That(_nutriRequ1.fat, Is.EqualTo(69.7));
            Assert.That(_nutriRequ2.fat, Is.EqualTo(58.8));
        }

        [Test]
        public void calcProteinNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(users[3]);
            _nutriRequ1 = new NutritionRequirement(users[2]);

            Assert.That(_nutriRequ0.protein, Is.EqualTo(64.6));
            Assert.That(_nutriRequ1.protein, Is.EqualTo(104.5));
        }



        [Test]
        public void calcBmr_Test()
        {
            var _fBmr = NutritionRequirement.CalcBMR(users[1]);
            var _mBmr = NutritionRequirement.CalcBMR(users[0]);

            Assert.That(_fBmr, Is.EqualTo(1239));
            Assert.That(_mBmr, Is.EqualTo(1655));
        }

        [Test]
        public void calcCalorieNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(users[5]);
            _nutriRequ1 = new NutritionRequirement(users[6]);
            _nutriRequ2 = new NutritionRequirement(users[7]);
            _nutriRequ3 = new NutritionRequirement(users[8]);
            _nutriRequ4 = new NutritionRequirement(users[9]);

            Assert.That(_nutriRequ0.calories, Is.EqualTo(1486));
            Assert.That(_nutriRequ1.calories, Is.EqualTo(1703));
            Assert.That(_nutriRequ2.calories, Is.EqualTo(1920));
            Assert.That(_nutriRequ3.calories, Is.EqualTo(2137));
            Assert.That(_nutriRequ4.calories, Is.EqualTo(2354));
        }
    }
}