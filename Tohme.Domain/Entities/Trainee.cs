using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Shared.Abstraction;

        namespace Tohme.Domain.Entities
    {
        public class Trainee : BaseEntity
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Trainee(string name, int age)
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
