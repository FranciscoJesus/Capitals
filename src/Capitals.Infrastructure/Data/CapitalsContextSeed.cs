using Capitals.Core.Entities;
using CountryInfoService;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Capitals.Infrastructure.Data
{
    public class CapitalsContextSeed
    {
        public static async Task SeedAsync(CapitalsContext catalogContext,
            int? retry = 0)
        {
            CountryInfoServiceSoapTypeClient client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

            var result = await client.FullCountryInfoAllCountriesAsync();

            var countriesToInsert = new List<Country>();
            var countries = result.Body.FullCountryInfoAllCountriesResult.GroupBy(c => c.sName);
            foreach (var country in countries)
            {
                var countryToInsert = new Country(country.Key);
                var capitals = result.Body.FullCountryInfoAllCountriesResult.Where(c => c.sName == country.Key).Select(s => s.sCapitalCity).ToList();
                capitals.ForEach(capital =>
                {
                    countryToInsert.AddCapital(capital);
                });
                countriesToInsert.Add(countryToInsert);
            }
            await catalogContext.AddRangeAsync(countriesToInsert);
            await catalogContext.SaveChangesAsync();
        }

        static IEnumerable<Country> GetPreconfiguredItems()
        {
            var countries = new List<Country>()
            {
                new Country("España"),
            };

            countries.ForEach(c => 
            {
                c.AddCapital("");
            });

            return countries;
        }
    }
}
