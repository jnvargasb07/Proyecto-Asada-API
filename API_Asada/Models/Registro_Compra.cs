using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Asada.Models
{
    public class Registro_Compra
    {
        [Key]
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        [StringLength(50, ErrorMessage = "El numero de factura no puede exceder los 50 caracteres")]
        public String numero_factura { get; set; }
        [StringLength(50, ErrorMessage = "El numero de factura no puede exceder los 50 caracteres")]
        public String provedor { get; set; }
    }
}
