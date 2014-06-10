using GiftAidCalculator.Core.Calculations;
using GiftAidCalculator.Core._Infrastructure.Configuration;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Calculations
{
    public class CalculatorTests
    {
        Calculator _calculator;
        Mock<IProvideConfiguration> _configProvider;
        decimal _donation;
        Config _config;
        string _eventType;

        [SetUp]
        public void Setup()
        {
            _config = new Config();
            _eventType = "";

            _configProvider = new Mock<IProvideConfiguration>();
            _configProvider.Setup(x => x.GetConfiguration()).Returns(_config);

            _calculator = new Calculator(_configProvider.Object);
        }

        decimal execute()
        {
            return _calculator.Calculate(_donation, _eventType);
        }

        [TestCase(100, 0, 0)]
        [TestCase(100, 20, 25)]
        public void calculates_gift_aid_using_tax_rate_from_configuration(decimal donation, decimal taxRate, decimal expectedResult)
        {
            _donation = donation;
            _config.TaxRate = taxRate;

            var result = execute();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void adds_5_percent_supplement_to_running_events()
        {
            _donation = 100;
            _config.TaxRate = 20;
            _eventType = "running";

            var result = execute();

            Assert.AreEqual(26.25, result);
        }

        [Test]
        public void adds_3_percent_supplement_to_swimming_events()
        {
            _donation = 100;
            _config.TaxRate = 20;
            _eventType = "swimming";

            var result = execute();

            Assert.AreEqual(25.75, result);
        }

        [TestCase("other event type")]
        [TestCase("yet another event type")]
        [TestCase("")]
        [TestCase(null)]
        public void does_not_add_any_supplement_to_events_of_any_other_type(string type)
        {
            _donation = 100;
            _config.TaxRate = 20;
            _eventType = type;

            var result = execute();

            Assert.AreEqual(25, result);
        }
    }
}