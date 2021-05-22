using Capitals.EndToEndTest.Fakes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Capitals.EndToEndTest
{
    public class CapitalControllerTests : IClassFixture<WebApplicationFactory<FakeStartup>>
    {
        private readonly WebApplicationFactory<FakeStartup> _factory;
        public CapitalControllerTests(WebApplicationFactory<FakeStartup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetCapital()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("api/countries/Spain/capitals");
        }
    }
}
