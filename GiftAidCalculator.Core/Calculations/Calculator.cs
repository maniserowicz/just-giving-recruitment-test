using System.Collections.Generic;
using GiftAidCalculator.Core._Infrastructure.Configuration;

namespace GiftAidCalculator.Core.Calculations
{
    public class Calculator : ICalculateGiftAid
    {
        private readonly IProvideConfiguration _configProvider;

        readonly Dictionary<string, decimal> _supplements = new Dictionary<string, decimal>
        {
            {"running", 0.05m},
            {"swimming", 0.03m}
        };

        public Calculator(IProvideConfiguration configProvider)
        {
            _configProvider = configProvider;
        }

        public decimal Calculate(decimal donation, string eventType)
        {
            decimal taxRate = _configProvider.GetConfiguration().TaxRate;

            decimal originalAmount = donation * (taxRate / (100 - taxRate));

            decimal supplement = get_supplement_for_event_type(eventType);

            return originalAmount + (originalAmount * supplement);
        }

        private decimal get_supplement_for_event_type(string eventType)
        {
            eventType = eventType ?? string.Empty;

            decimal supplement;
            _supplements.TryGetValue(eventType, out supplement);

            return supplement;
        }
    }
}