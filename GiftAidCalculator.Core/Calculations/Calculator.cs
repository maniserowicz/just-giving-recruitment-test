using GiftAidCalculator.Core._Infrastructure.Configuration;

namespace GiftAidCalculator.Core.Calculations
{
    public class Calculator : ICalculateGiftAid
    {
        private readonly IProvideConfiguration _configProvider;

        public Calculator(IProvideConfiguration configProvider)
        {
            _configProvider = configProvider;
        }

        public decimal Calculate(decimal donation)
        {
            decimal taxRate = _configProvider.GetConfiguration().TaxRate;

            return donation*(taxRate/(100 - taxRate));
        }
    }
}