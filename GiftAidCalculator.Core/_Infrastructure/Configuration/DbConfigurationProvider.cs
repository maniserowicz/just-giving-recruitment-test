using GiftAidCalculator.Core.DataAccess;

namespace GiftAidCalculator.Core._Infrastructure.Configuration
{
    public class DbConfigurationProvider : IProvideConfiguration
    {
        private readonly IProvideTaxRateFromDatabase _taxRateDatabaseProvider;

        public DbConfigurationProvider(IProvideTaxRateFromDatabase taxRateDatabaseProvider)
        {
            _taxRateDatabaseProvider = taxRateDatabaseProvider;
        }

        public Config GetConfiguration()
        {
            return new Config
            {
                TaxRate = _taxRateDatabaseProvider.GetTaxRate()
            };
        }
    }
}