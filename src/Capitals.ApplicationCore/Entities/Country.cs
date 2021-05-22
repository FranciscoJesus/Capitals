using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace Capitals.Core.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<Capital> _capitals = new List<Capital>();
        public IReadOnlyCollection<Capital> Capitals => _capitals.AsReadOnly();

        public Country(string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void AddCapital(string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            var capital = _capitals.FirstOrDefault(c => c.Name == name);

            if (capital is null)
            {
                _capitals.Add(new Capital(Id, name));
            }
        }
    }
}
