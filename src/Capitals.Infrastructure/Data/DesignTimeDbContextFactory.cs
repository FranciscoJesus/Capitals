using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitals.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CapitalsContext>
    {
        public CapitalsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("connection-string.json", false)
               .Build();

            var connectionString = configuration.GetConnectionString("CapitalsConnectionString");
            Console.WriteLine($"Connecting to -> {connectionString}");
            var builder = new DbContextOptionsBuilder<CapitalsContext>();
            builder.UseSqlServer(connectionString);
            return new CapitalsContext(builder.Options);
        }
    }
}
