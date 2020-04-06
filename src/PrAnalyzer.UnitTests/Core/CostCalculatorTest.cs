using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;
using PrAnalyzer.Core.Entities;
using PrAnalyzer.Core.Services;
using Xunit;

namespace PrAnalyzer.UnitTests.Core
{
    public class CostCalculatorTest
    {
        private ICostCalculator CostCalculator;
        public CostCalculatorTest()
        {
            CostCalculator = new CostCalculator();
        }

        [Theory]
        [InlineData(3500, ProductType.Basic, 830)]
        [InlineData(4500, ProductType.Basic, 1050)]
        [InlineData(6000, ProductType.Basic, 1380)]
        [InlineData(0, ProductType.Basic, 60)]
        [InlineData(3500, ProductType.Package, 800)]
        [InlineData(4500, ProductType.Package, 950)]
        [InlineData(6000, ProductType.Package, 1400)]
        [InlineData(0, ProductType.Package, 800)]
        public void CorrectCalculations(decimal consumption, ProductType productType, decimal result)
        {
            var product = new Product(string.Empty, productType);
            Assert.Equal(result, CostCalculator.Calculate(product, consumption));
        }

    }
}
