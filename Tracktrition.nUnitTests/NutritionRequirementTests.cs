using System.Runtime.CompilerServices;
using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class NutritionRequirementTests
    {

        private UserData _mUser { get; set; } = null!;
        private UserData _fUser { get; set; } = null!;
        private UserData _babyUser { get; set; } = null!;
        private UserData _childUser { get; set; } = null!;
        private UserData _adultUser { get; set; } = null!;
        private UserData _1User { get; set; } = null!;
        private UserData _2User { get; set; } = null!;
        private UserData _3User { get; set; } = null!;
        private UserData _4User { get; set; } = null!;
        private UserData _5User { get; set; } = null!;
        private NutritionRequirement _nutriRequ0 { get; set; } = null!;
        private NutritionRequirement _nutriRequ1 { get; set; } = null!;
        private NutritionRequirement _nutriRequ2 { get; set; } = null!;
        private NutritionRequirement _nutriRequ3 { get; set; } = null!;
        private NutritionRequirement _nutriRequ4 { get; set; } = null!;


        [SetUp]
        public void Setup()
        {
            _mUser = new UserData("Max", 'm', 30, 70, 176, 2);
            _fUser = new UserData("Lisa", 'f', 30, 55, 160, 3);
            _childUser = new UserData("Kindername", 'f', 8, 55, 160, 3);
            _babyUser = new UserData("Babyname", 'f', 0, 55, 160, 3);
            _adultUser = new UserData("Adult", 'f', 25, 55, 160, 3);
            _1User = new UserData("Lisa", 'f', 30, 55, 160, 1);
            _2User = new UserData("Lisa", 'f', 30, 55, 160, 2);
            _3User = new UserData("Lisa", 'f', 30, 55, 160, 3);
            _4User = new UserData("Lisa", 'f', 30, 55, 160, 4);
            _5User = new UserData("Lisa", 'f', 30, 55, 160, 5);
        }


        [Test]
        public void calcFatNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(_babyUser);
            _nutriRequ1 = new NutritionRequirement(_childUser);
            _nutriRequ2 = new NutritionRequirement(_adultUser);

            Assert.That(_nutriRequ0.fat, Is.EqualTo(83.7));
            Assert.That(_nutriRequ1.fat, Is.EqualTo(69.7));
            Assert.That(_nutriRequ2.fat, Is.EqualTo(58.8));
        }

        [Test]
        public void calcProteinNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(_babyUser);
            _nutriRequ1 = new NutritionRequirement(_childUser);

            Assert.That(_nutriRequ0.protein, Is.EqualTo(64.6));
            Assert.That(_nutriRequ1.protein, Is.EqualTo(104.5));
        }



        [Test]
        public void calcBmr_Test()
        {
            var _fBmr = NutritionRequirement.calcBMR(_fUser);
            var _mBmr = NutritionRequirement.calcBMR(_mUser);

            Assert.That(_fBmr, Is.EqualTo(1239));
            Assert.That(_mBmr, Is.EqualTo(1655));
        }

        [Test]
        public void calcCalorieNeed_Test()
        {
            _nutriRequ0 = new NutritionRequirement(_1User);
            _nutriRequ1 = new NutritionRequirement(_2User);
            _nutriRequ2 = new NutritionRequirement(_3User);
            _nutriRequ3 = new NutritionRequirement(_4User);
            _nutriRequ4 = new NutritionRequirement(_5User);

            Assert.That(_nutriRequ0.calories, Is.EqualTo(1486));
            Assert.That(_nutriRequ1.calories, Is.EqualTo(1703));
            Assert.That(_nutriRequ2.calories, Is.EqualTo(1920));
            Assert.That(_nutriRequ3.calories, Is.EqualTo(2137));
            Assert.That(_nutriRequ4.calories, Is.EqualTo(2354));
        }
    }
}