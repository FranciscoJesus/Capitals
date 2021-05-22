using Ardalis.GuardClauses;

namespace Capitals.Core.Entities
{
    public class Capital : BaseEntity
    {
        public int Id { get; private set; }
        public int CountryId { get; private set; }
        public string Name { get; private set; }

        public virtual Country Country { get; private set; }
        public Capital(int countryId, string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));

            CountryId = countryId;
            Name = name;
        }
    }
}
