using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asada.Models
{
    public class AsadaContext : DbContext
    {
        public AsadaContext(DbContextOptions<AsadaContext> options)
        : base(options)
        {

        }
        public DbSet<Cloracion> Cloracion { get; set; }
        public DbSet<Aforo> Aforo { get; set; }
        public DbSet<Agua_No_Contabilizada> Agua_No_Contabilizada { get; set; }
    }
}
