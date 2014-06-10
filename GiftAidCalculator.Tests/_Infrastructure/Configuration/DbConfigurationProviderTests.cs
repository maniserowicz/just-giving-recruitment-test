using GiftAidCalculator.Core.DataAccess;
using GiftAidCalculator.Core._Infrastructure.Configuration;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests._Infrastructure.Configuration
{
    public class DbConfigurationProviderTests
    {
        DbConfigurationProvider _provider;
        Mock<IProvideTaxRateFromDatabase> _taxRateProvider;

        [SetUp]
        public void Setup()
        {
            _taxRateProvider = new Mock<IProvideTaxRateFromDatabase>();

            _provider = new DbConfigurationProvider(_taxRateProvider.Object);
        }

        Config execute()
        {
            return _provider.GetConfiguration();
        }

        [TestCase(10)]
        [TestCase(70)]
        public void returns_configuration_object_with_tax_rate_read_from_database(decimal taxRateFromDb)
        {
            _taxRateProvider.Setup(x => x.GetTaxRate()).Returns(taxRateFromDb);

            var result = execute();

            Assert.AreEqual(taxRateFromDb, result.TaxRate);
        }
    }
}