namespace GiftAidCalculator.Core.DataAccess
{
    public class TaxRateDatabaseProvider : IProvideTaxRateFromDatabase
    {
        public decimal GetTaxRate()
        {
            // create and open connection...
            // select top 1 taxrate from configuration...

            return 20;
        }
    }
}