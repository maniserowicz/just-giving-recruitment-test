using System.Globalization;

namespace GiftAidCalculator.Core.Formatting
{
    public class TwoDecimalPlacesGiftAidFormatter : IFormatGiftAidForDonors
    {
        public string Format(decimal amount)
        {
            return amount.ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}