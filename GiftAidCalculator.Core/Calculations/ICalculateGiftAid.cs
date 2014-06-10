namespace GiftAidCalculator.Core.Calculations
{
    public interface ICalculateGiftAid
    {
        decimal Calculate(decimal donation, string eventType);
    }
}