using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public String material { get; set; } 
    }
}
