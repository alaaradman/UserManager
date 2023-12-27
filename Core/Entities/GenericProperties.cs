using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class GenericProperties
    {
        public abstract string Id { get; set; } 
        public abstract string Name { get; set; }
    }
}
