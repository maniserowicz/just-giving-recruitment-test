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

        [SetUp]
        public void Setup()
        {
            _config = new Config();

            _configProvider = new Mock<IProvideConfiguration>();
            _configProvider.Setup(x => x.GetConfiguration()).Returns(_config);

            _calculator = new Calculator(_configProvider.Object);
        }

        decimal execute()
        {
            return _calculator.Calculate(_donation);
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
    }
}