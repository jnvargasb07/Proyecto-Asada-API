using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Agua_No_Contabilizada
    {
        public int Id { get; set; }
        [StringLength(2)]
        public String sector { get; set; }
        public Double lectura_anterior { get; set; }
        public Double lectura_actual { get; set; }
        public DateTime fecha { get; set; }
    }
}
