using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Shared.Abstraction;

namespace Tohme.Domain.Entities
{
    public class Protein:BaseEntity
    {
        public string Name { get; set; }

        public Protein(string name)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}
