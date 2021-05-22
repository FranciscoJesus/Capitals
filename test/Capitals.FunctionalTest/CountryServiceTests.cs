using Capitals.Core.Interfaces;
using Capitals.FunctionalTest.DataInitializer;
using Capitals.FunctionalTest.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Capitals.FunctionalTest
{
    public class CountryServiceTests : IClassFixture<CapitalsFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        public CountryServiceTests(CapitalsFixture capitalsFixture)
        {
            _serviceProvider = capitalsFixture.ServiceProvider;
        }

        [Theory]
        [MemberData(nameof(DataGenerator.CapitalsAndCountries), MemberType = typeof(DataGenerator))]
        public async Task GetCapital(string country, IEnumerable<string> capitals)
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            var capitalsResult = await countryService.GetCapitalsByCountryName(country);
            capitalsResult.Select(s => s.Name).Should().BeEquivalentTo(capitals);
        }

        [Fact]
        public async Task GetCapitalFromNull()
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            var capitalsResult = await countryService.GetCapitalsByCountryName(null);
            capitalsResult.Should().BeNullOrEmpty();
        }
    }
}
