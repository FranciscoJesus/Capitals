using AutoMapper;
using Capitals.Core.Interfaces;
using Capitals.Core.Services;
using Capitals.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Capitals.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<CapitalsContext>(c =>
                 c.UseInMemoryDatabase("Capitals"));
            }
            else
            {
                services.AddDbContext<CapitalsContext>(c =>
                c.UseSqlServer(Configuration.GetValue<string>("Settings:ConnectionString")));
            }
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICapitalsContext, CapitalsContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
