namespace GiftAidCalculator.Core.DataAccess
{
    public interface IProvideTaxRateFromDatabase
    {
        decimal GetTaxRate();
    }
}