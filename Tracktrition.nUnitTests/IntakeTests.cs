using Tracktrition.Data;

namespace Tracktrition.nUnitTests
{
    public class IntakeTests
    {

        private DateTime _todaysDateFake;
        //private Intake _intake;
        private Food _food = null!;

        [SetUp]
        public void Setup()
        {
            _todaysDateFake = new DateTime(2023, 01, 01);
            _food = new Food("test food", 300, 10, 20, 30);
            //_intake = new Intake(_todaysDateFake, 100, _food);
        }

        [Test] 
        public void Intake_Test()
        {
            var _intake = new Intake(_todaysDateFake, 400, _food);

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