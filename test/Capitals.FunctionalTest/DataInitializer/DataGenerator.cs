using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitals.FunctionalTest.DataInitializer
{
    public static class DataGenerator
    {
        public static IEnumerable<object[]> CapitalsAndCountries() =>
            new List<object[]>
            {
                new object[]
                {
                    "Spain",
                    new List<string> {"Madrid"}
                },
                new object[]
                {
                    "Bolivia",
                    new List<string> { "La Paz", "Sucre" }
                },
            };
    }
}
