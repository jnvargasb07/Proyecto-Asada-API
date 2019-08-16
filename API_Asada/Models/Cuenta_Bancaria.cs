using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Cuenta_Bancaria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public String numero_cuenta { get; set; }
        [StringLength(3)]
        public String tipo_banco { get; set; }
    }
}
