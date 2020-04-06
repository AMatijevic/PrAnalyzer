using PrAnalyzer.Contracts.Dto;
using PrAnalyzer.IntegrationTests.Fixtures;
using PrAnalyzer.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PrAnalyzer.IntegrationTests
{
    public class ElectricityControllerTest
    {
        public class ElectricityControllerBaseTest : HttpClientFixture
        {
            public ElectricityControllerBaseTest(WebApiFactoryFixture<Startup> factory) : base(factory) { }

            protected Uri GetProducts(decimal consumption) => new Uri($"api/Electricity/Products/{consumption}", UriKind.Relative);
        }


        public class GetComparedProductsTest : ElectricityControllerBaseTest
        {
            public GetComparedProductsTest(WebApiFactoryFixture<Startup> factory) : base(factory) { }

            [Theory]
            [InlineData(3500, "Packaged tariff", 800, "Basic electricity tariff", 830)]
            [InlineData(4500, "Packaged tariff", 950, "Basic electricity tariff", 1050)]
            [InlineData(6000, "Basic electricity tariff", 1380, "Packaged tariff", 1400)]
            [InlineData(0, "Basic electricity tariff", 60, "Packaged tariff", 800)]
            public async Task Success(
                decimal consumption,
                string firstName,
                decimal firstCost,
                string lastName,
                decimal lastCost)
            {
                var products = await Get<IEnumerable<ProductDto>>(GetProducts(consumption));

                Assert.NotNull(products);

                Assert.NotEmpty(products);

                Assert.Equal(2, products.Count());

                var firstProduct = products.FirstOrDefault();

                var lastProduct = products.LastOrDefault();

                Assert.Equal(firstName, firstProduct.Name);

                Assert.Equal(firstCost, firstProduct.AnnualCosts);

                Assert.Equal(lastName, lastProduct.Name);

                Assert.Equal(lastCost, lastProduct.AnnualCosts);
            }
        }
    }
}
