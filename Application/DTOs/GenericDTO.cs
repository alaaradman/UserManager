using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public abstract class GenericDTO
    {
        public abstract string? Id {  get; set; } 
        public abstract string Name { get; set; }    
    }
}
