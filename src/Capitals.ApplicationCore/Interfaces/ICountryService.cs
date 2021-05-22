using Capitals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitals.Core.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Capital>> GetCapitalsByCountryName(string countryName);
    }
}
