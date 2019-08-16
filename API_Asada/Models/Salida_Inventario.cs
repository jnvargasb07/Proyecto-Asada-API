using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Asada.Models
{
    public class Salida_Inventario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Inventario_Stock")]
        public int Id_articulo { get; set; }
        public virtual Inventario_Stock Inventario_Stock { get; set; }
        [ForeignKey("Registro_Salida")]
        public int Id_salida { get; set; }
        public virtual Registro_Salida Registro_Salida { get; set; }
        public int cantidad { get; set; }
        public Char tipo { get; set; }
        public DateTime fecha { get; set; }
    }
}
