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
        public DbSet<Material> Material { get; set; }
        public DbSet<Reciclaje> Reciclaje { get; set; }
        public DbSet<Inventario_Stock> Inventario_Stock { get; set; }
        public DbSet<Registro_Compra> Registro_Compra { get; set; }
        public DbSet<Registro_Salida> Registro_Salida { get; set; }
        public DbSet<Compra_Inventario> Compra_Inventario { get; set; }
        public DbSet<Salida_Inventario> Salida_Inventario { get; set; }
        public DbSet<Prestamo_Inventario> Prestamo_Inventario { get; set; }
        public DbSet<Asada_Queja> Asada_Queja { get; set; }
        public DbSet<Averia> Averia { get; set; }
        public DbSet<Inventario_Averia> Inventario_Averia { get; set; }
    }
}
