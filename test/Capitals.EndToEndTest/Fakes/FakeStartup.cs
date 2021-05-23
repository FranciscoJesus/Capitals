using Capitals.API;
using Capitals.Core.Entities;
using Capitals.Core.Interfaces;
using Capitals.Core.Services;
using Capitals.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Capitals.EndToEndTest.Fakes
{
    public class FakeStartup : Startup
    {
        public FakeStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration, environment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(Startup).Assembly);
            services.AddDbContext<CapitalsContext>(c =>
             c.UseInMemoryDatabase("Capitals"));
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICapitalsContext, CapitalsContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddAutoMapper(typeof(Startup).Assembly);

            var serviceProvider = services.BuildServiceProvider();
            var capitalContext = serviceProvider.GetService<ICapitalsContext>();
            CapitalsContextSeed(capitalContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void CapitalsContextSeed(ICapitalsContext capitalContext)
        {
            var spain = new Country("Spain");
            spain.AddCapital("Madrid");


            var bolivia = new Country("Bolivia");
            bolivia.AddCapital("La Paz");
            bolivia.AddCapital("Sucre");

            var countries = new List<Country> { spain, bolivia };

            capitalContext.Countries.AddRange(countries);
            capitalContext.SaveChanges();
        }
    }
}
