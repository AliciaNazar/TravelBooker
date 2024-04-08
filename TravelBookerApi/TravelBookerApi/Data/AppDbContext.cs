using Microsoft.EntityFrameworkCore;
using TravelBookerApi.Models;

namespace TravelBookerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Butaca> Butacas { get; set; }
        public DbSet<Colectivo> Colectivos { get; set;}
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        
    }
}
    