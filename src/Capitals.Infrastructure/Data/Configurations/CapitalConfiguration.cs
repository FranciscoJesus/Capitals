using Capitals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitals.Infrastructure.Data.Configurations
{
    public class CapitalConfiguration : IEntityTypeConfiguration<Capital>
    {
        public void Configure(EntityTypeBuilder<Capital> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.HasOne(ho => ho.Country).WithMany(wm => wm.Capitals).HasForeignKey(fk => fk.CountryId);
        }
    }
}
