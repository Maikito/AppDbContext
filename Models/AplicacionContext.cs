using Microsoft.EntityFrameworkCore;

namespace AppDbContext.Models
{
    public class AplicacionContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=DelgadoApiREST; Integrated Security=True; Trust Server Certificate=True");
        }
    }
}
