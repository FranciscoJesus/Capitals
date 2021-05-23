using Capitals.API.ViewModels;
using Capitals.EndToEndTest.Fakes;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace Capitals.EndToEndTest
{
    public class CapitalControllerTests : IClassFixture<CapitalsWebApplicationFactory>
    {
        private readonly CapitalsWebApplicationFactory _factory;
        public CapitalControllerTests(CapitalsWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetCapital()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/api/countries/Spain/capitals");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            var capitals = await Deserialize<IEnumerable<CapitalViewModel>>(result);
            capitals.Should().HaveCount(1);
            capitals.FirstOrDefault().Name.Should().Be("Madrid");
        }

        [Fact]
        public async Task CountryDoesnotExist()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/api/countries/Cataluña/capitals");

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            using var sr = new StreamReader(responseStream);
            using JsonReader reader = new JsonTextReader(sr);
            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }
    }
}