using PlantillaEjemplo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlantillaEjemplo.Client.Pages;

namespace PlantillaEjemplo.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Adscripciones> Adscripciones { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Inventario1> Inventario { get; set; }
    }
}
