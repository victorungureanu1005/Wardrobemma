using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobemma.Models
{
    public class GarmentStyle
    {
        public int GarmentStyleID{get;set;}

        public string Name{get;set;}
        
        public ICollection<Garment> Garments{get;set;}
    }
}