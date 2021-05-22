using Capitals.Core.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Capitals.UnitTest
{
    public class CountryTests
    {
        [Fact]
        public void CreateCountry()
        {
            var country = new Country("Spain");

            country.Name.Should().Be("Spain");
        }

        [Fact]
        public void CreateCountryAndAddCapital()
        {
            var country = new Country("Spain");
            country.AddCapital("Madrid");

            country.Name.Should().Be("Spain");
            country.Capitals.FirstOrDefault().Name.Should().Be("Madrid");
        }

        [Fact]
        public void CreateCountryAndAddTwoCapitals()
        {
            var country = new Country("Bolivia");
            country.AddCapital("La Paz");
            country.AddCapital("Sucre");

            country.Name.Should().Be("Bolivia");
            country.Capitals.FirstOrDefault(c => c.Name == "La Paz").Should().NotBeNull();
            country.Capitals.FirstOrDefault(c => c.Name == "Sucre").Should().NotBeNull();
        }

        [Fact]
        public void CreateCountryAndAddTwoCapitalsSameName()
        {
            var country = new Country("Spain");
            country.AddCapital("Madrid");
            country.AddCapital("Madrid");

            country.Name.Should().Be("Spain");
            country.Capitals.FirstOrDefault().Name.Should().Be("Madrid");
            country.Capitals.Count.Should().Be(1);
        }

        [Fact]
        public void CreateCountryNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Country(null));
        }

        [Fact]
        public void CreateCountryStringEmpry()
        {
            Assert.Throws<ArgumentException>(() => new Country(string.Empty));
        }
    }
}
