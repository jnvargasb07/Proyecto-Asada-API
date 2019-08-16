using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Aforo
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime tiempo { get; set; }
        public double litros { get; set; }

    }
}
