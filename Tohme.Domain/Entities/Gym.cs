using Tohme.Shared.Abstraction;

namespace Tohme.Domain.Entities
{
    public class Gym : BaseEntity
    {
        public string Name { get; set; }

        public Gym(string name)
        {
            Name = name;
        }

        public void Update(string name)
            => Name = name;
    }
}
