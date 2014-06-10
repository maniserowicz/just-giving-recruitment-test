using System;
using GiftAidCalculator.Core.Calculations;
using GiftAidCalculator.Core.DataAccess;
using GiftAidCalculator.Core.Formatting;
using GiftAidCalculator.Core._Infrastructure.Configuration;

namespace GiftAidCalculator.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter donation amount:");
            decimal donationAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter event type:");
            string eventType = Console.ReadLine();

            var calculator = new Calculator(new DbConfigurationProvider(new TaxRateDatabaseProvider()));

            decimal giftAidAmount = calculator.Calculate(donationAmount, eventType);
            var formatter = new TwoDecimalPlacesGiftAidFormatter();
            string toDisplay = formatter.Format(giftAidAmount);

            Console.WriteLine(toDisplay);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
