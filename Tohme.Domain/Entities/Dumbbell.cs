using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Shared.Abstraction;

namespace Tohme.Domain.Entities
{
    public class Dumbbell :BaseEntity 
    { 
        public int Weight { get; set; }

        public Dumbbell(int weight)
        {
            Weight = weight;
        }
        public void Update(int weight)
        { 
            Weight = weight;

        }
    }

}
