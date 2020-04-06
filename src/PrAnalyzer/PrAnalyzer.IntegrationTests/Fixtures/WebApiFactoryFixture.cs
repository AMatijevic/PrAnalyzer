using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using PrAnalyzer.WebApi;

namespace PrAnalyzer.IntegrationTests.Fixtures
{
    public class WebApiFactoryFixture<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => { });
        }

    }
}
