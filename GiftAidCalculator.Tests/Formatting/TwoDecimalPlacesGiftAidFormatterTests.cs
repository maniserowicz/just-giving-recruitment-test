using GiftAidCalculator.Core.Formatting;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Formatting
{
    public class TwoDecimalPlacesGiftAidFormatterTests
    {
        TwoDecimalPlacesGiftAidFormatter _formatter;
        decimal _amount;

        [SetUp]
        public void Setup()
        {
            _formatter = new TwoDecimalPlacesGiftAidFormatter();
        }

        string execute()
        {
            return _formatter.Format(_amount);
        }

        [TestCase(1.316, "1.32")]
        [TestCase(2, "2.00")]
        public void formats_decimals_with_rounding_to_two_decimal_places(decimal amount, string expectedResult)
        {
            _amount = amount;

            var result = execute();

            Assert.AreEqual(expectedResult, result);
        }
    }
}