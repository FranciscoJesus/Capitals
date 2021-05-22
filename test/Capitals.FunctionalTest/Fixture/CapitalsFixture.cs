using Capitals.Core.Entities;
using Capitals.Core.Interfaces;
using Capitals.Core.Services;
using Capitals.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace Capitals.FunctionalTest.Fixture
{
    public class CapitalsFixture
    {
        public IServiceProvider ServiceProvider { get; }
        public CapitalsFixture()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<CapitalsContext>(c =>
             c.UseInMemoryDatabase("Capitals"));
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICapitalsContext, CapitalsContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));

            ServiceProvider = services.BuildServiceProvider();

            var capitalContext = ServiceProvider.GetService<ICapitalsContext>();
            CapitalsContextSeed(capitalContext);
        }

        private void CapitalsContextSeed(ICapitalsContext capitalContext)
        {
            var spain = new Country("Spain");
            spain.AddCapital("Madrid");


            var bolivia = new Country("Bolivia");
            bolivia.AddCapital("La Paz");
            bolivia.AddCapital("Sucre");

            var countries = new List<Country> { spain , bolivia };

            capitalContext.Countries.AddRange(countries);
            capitalContext.SaveChanges();
        }
    }
}
