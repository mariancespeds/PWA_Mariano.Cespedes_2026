using Microsoft.AspNetCore.Mvc;
using SitioWebPwa.Models;

namespace SitioWebPwa.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Tienda()
        {
            var products = ObtenerProductos().Take(8).ToList();
            var modelo = new ProductosVM()
            {
                productos = products
            };
            return View(modelo);
        }
        public List<Producto> ObtenerProductos()
        {
            return new List<Producto>
            {
                new Producto
                {
                    NombreProducto="Camiseta Titular",
                    Detalle="Camiseta titular de juego unisex",
                    Precio= 50000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Camiseta Suplente",
                    Detalle="Camiseta Suplente de juego unisex",
                    Precio= 50000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Short Titular",
                    Detalle="Short titular de juego unisex",
                    Precio= 25000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Short Suplente",
                    Detalle="Short suplente Camiseta titular de juego unisex",
                    Precio= 25000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Camiseta Titular",
                    Detalle="Camiseta titular de juego unisex",
                    Precio= 50000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Buzo ",
                    Detalle="Buzo DCVD",
                    Precio= 80000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Piluso",
                    Detalle="Piluso Vamos Violeta",
                    Precio= 20000.00,
                    Imagen=""
                },
                new Producto
                {
                    NombreProducto="Medias de futbol",
                    Detalle="Medias de futbol DCVD",
                    Precio= 10000.00,
                    Imagen=""
                },
            };
        }
    }
}
