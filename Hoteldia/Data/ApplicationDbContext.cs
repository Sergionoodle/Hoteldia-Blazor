using Hoteldia.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hoteldia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Agregamos los modelos
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Propiedad> Propiedad { get; set; }
        public DbSet<ImagenPropiedad> ImagenPropiedad { get; set; }
    }
}