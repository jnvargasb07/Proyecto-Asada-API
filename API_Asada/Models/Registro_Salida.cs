using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Registro_Salida
    {
        [Key]
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        [Column(TypeName="text")]
        public String motivo { get; set; }
    }
}
