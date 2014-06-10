using System;
using System.Configuration;

namespace GiftAidCalculator.Core._Infrastructure.Configuration
{
    public class AppSettingsConfigurationProvider : IProvideConfiguration
    {
        public Config GetConfiguration()
        {
            return new Config
            {
                TaxRate = Convert.ToDecimal(ConfigurationManager.AppSettings["tax-rate"])
            };
        }
    }
}