using Microsoft.EntityFrameworkCore;

namespace SitioWebPwa.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasData(
                new Producto { CodigoProducto = 1, NombreProducto = "Camiseta Titular", Detalle = "Camiseta titular de juego unisex", Precio = 50000.00, Imagen = "/img/CamisetaTitularDeca.png" },
                new Producto { CodigoProducto = 2, NombreProducto = "Camiseta Suplente", Detalle = "Camiseta Suplente de juego unisex", Precio = 50000.00, Imagen = "/img/CamisetaSuplenteDeca.png" },
                new Producto { CodigoProducto = 3, NombreProducto = "Short Titular", Detalle = "Short titular de juego unisex", Precio = 25000.00, Imagen = "/img/ShortTitularDeca.png" },
                new Producto { CodigoProducto = 4, NombreProducto = "Short Suplente", Detalle = "Short suplente Camiseta titular de juego unisex", Precio = 25000.00, Imagen = "/img/ShortSuplenteDeca.png" },
                new Producto { CodigoProducto = 5, NombreProducto = "Kit Matero", Detalle = "Termo y Mate del violeta", Precio = 65000.00, Imagen = "/img/KitMateroDeca.png" },
                new Producto { CodigoProducto = 6, NombreProducto = "Buzo Decaño", Detalle = "Buzo DCVD", Precio = 80000.00, Imagen = "/img/BuzoDeca.png" },
                new Producto { CodigoProducto = 7, NombreProducto = "Piluso", Detalle = "Piluso Vamos Violeta", Precio = 20000.00, Imagen = "/img/PilusoDeca.png" },
                new Producto { CodigoProducto = 8, NombreProducto = "Medias de futbol", Detalle = "Medias de futbol DCVD", Precio = 10000.00, Imagen = "/img/MediasDeca.png" }
            );
        }
    }
}
