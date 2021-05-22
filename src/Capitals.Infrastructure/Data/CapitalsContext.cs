using Capitals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Capitals.Infrastructure.Data
{
    public class CapitalsContext : DbContext, ICapitalsContext
    {
        public CapitalsContext(DbContextOptions<CapitalsContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Capital> Capitals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
