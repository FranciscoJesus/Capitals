using Ardalis.Specification;
using Capitals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitals.Core.Specifications
{
    public sealed class CountrySpecification : Specification<Country>
    {
        public CountrySpecification(string name)
        {
            Query
                .AsNoTracking()
                .Include(c => c.Capitals)
                .Where(c => c.Name == name);
        }
    }
}
