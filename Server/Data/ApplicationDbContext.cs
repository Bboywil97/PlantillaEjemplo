using PlantillaEjemplo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
    }
}
