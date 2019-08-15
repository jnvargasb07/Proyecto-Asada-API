using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Asada.Models
{
    public class Asada_Queja
    {
        [Key]
        public int Id { get; set; }
        public String numero_casa { get; set; }
        [Column(TypeName = "text")]
        public String descripcion { get; set; }
        public DateTime fecha { get; set; }
    }
}
