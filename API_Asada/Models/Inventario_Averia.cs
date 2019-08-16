using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Asada.Models
{
    public class Inventario_Averia
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Inventario_Stock")]
        public int Id_articulo { get; set; }
        public virtual Inventario_Stock Inventario_Stock { get; set; }
        [ForeignKey("Averia")]
        public int Id_averia { get; set; }
        public virtual Averia Averia { get; set; }
        public int cantidad { get; set; }
    }
}
