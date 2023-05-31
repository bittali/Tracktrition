using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class IntakeTests
    {

        private DateTime _todaysDateFake;
        private FoodLoaderMock foodLoaderMock = new FoodLoaderMock();
        private Food testFood;

        [SetUp]
        public void Setup()
        {
            _todaysDateFake = new DateTime(2023, 01, 01);
            testFood = foodLoaderMock.ReadFoodFromFile()[0];
        }

        [Test] 
        public void Intake_Test()
        {
            var _intake = new Intake(_todaysDateFake, 400, testFood);

            Assert.That(_intake.date, Is.EqualTo(new DateTime(2023, 01, 01)));
            Assert.That(_intake.amount, Is.EqualTo(400));
            Assert.That(_intake.calories, Is.EqualTo(1200));
            Assert.That(_intake.fat, Is.EqualTo(40));
            Assert.That(_intake.protein, Is.EqualTo(80));
            Assert.That(_intake.carbs, Is.EqualTo(120));
        }

        [Test]
        public void calcPerAmount_Test()
        {
            var data = 120.0;
            var amount = 200.0;

            var result = AmountCalculator.CalculatePerAmount(data, amount);

            Assert.That(result, Is.EqualTo(240.0));
        }
    }
}