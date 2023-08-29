using Tohme.Shared.Abstraction;

namespace Tohme.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Trainer(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public void Update(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

}
