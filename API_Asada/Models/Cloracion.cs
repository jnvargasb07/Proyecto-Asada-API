using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Cloracion
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public double ppm { get; set; }
        public char sector { get; set; }

    }
}
