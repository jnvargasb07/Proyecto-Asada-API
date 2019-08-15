using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Asada.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public String numero_factura { get; set; }
        public Double monto { get; set; }
        public Boolean destino { get; set; }

    }
}
