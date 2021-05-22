using Capitals.Core.Entities;
using Capitals.Core.Interfaces;
using Capitals.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capitals.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IAsyncRepository<Country> _countryRepository;
        public CountryService(IAsyncRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Capital>> GetCapitalsByCountryName(string countryName)
        {
            var countrySpecification = new CountrySpecification(countryName);
            var country = await _countryRepository.FirstOrDefaultAsync(countrySpecification);

            return country is null ? null : country.Capitals;
        }
    }
}
