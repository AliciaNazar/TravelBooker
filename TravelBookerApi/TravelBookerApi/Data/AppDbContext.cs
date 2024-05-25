using Microsoft.EntityFrameworkCore;
using TravelBookerApi.Models;

namespace TravelBookerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Butaca> Butacas { get; set; }
        public DbSet<Colectivo> Colectivos { get; set;}
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<CategoriaButaca> CategoriasButacas { get; set; }
        
    }
}
    