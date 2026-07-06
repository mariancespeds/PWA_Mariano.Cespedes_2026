using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SitioWebPwa.Helpers;
using SitioWebPwa.Models;
using SitioWebPwa.ViewModels;
using System.Security.Cryptography;

namespace SitioWebPwa.Controllers
{
    public class TiendaController : Controller
    {
        public List<Producto> Productos = new List<Producto>();
        public List<ItemView> listaCarrito = new List<ItemView>();
        int contar = 0;
        private readonly ApplicationDbContext _context;
        public TiendaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Tienda()
        {
            int cantidad;
            var cart= SessionsHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cantidad= 0;
            }
            else
            {
                cantidad = cart.Count();
            }
            TempData["Contar"]=cantidad;
            Productos=_context.Productos.ToList();
            return View(Productos);
        }
        public IActionResult Carrito()
        {
            var MyCart = SitioWebPwa.Helpers.SessionsHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "cart");
            if(MyCart == null)
            {
                return RedirectToAction("Tienda");
            }
            else
            {
                return View(MyCart);
            }
        }
        public int ContarItems(List<ItemView> items)
        {
            int cantidad = items.Count();
            return cantidad;
        }
        public int Exist(List<ItemView> cart, string id)
        {
   
            if (!int.TryParse(id, out int idEntero))
            {
                return -1; 
            }

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].producto.CodigoProducto == idEntero)
                {
                    return i; 
                }
            }

            return -1; 
        }
        [HttpGet]
        public IActionResult Cart(string id)
        {
            if (!int.TryParse(id, out int idEntero))
            {
                return RedirectToAction("Tienda");
            }

            var product = _context.Productos.Find(idEntero);

            // 2. Control de seguridad por si no lo encuentra
            if (product == null)
            {
                return RedirectToAction("Tienda");
            }

            var cart = SessionsHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<ItemView>();
                cart.Add(new ItemView()
                {
                    producto = product,
                    Cantidad = 1
                });
                TempData["Contar"] = ContarItems(cart);
                SessionsHelper.setobjectasjson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exist(cart, id);
                if (index == -1)
                {
                    cart.Add(new ItemView()
                    {
                        producto = product,
                        Cantidad = 1
                    });
                }
                else
                {
                    cart[index].Cantidad += 1;
                }
                TempData["Contar"] = ContarItems(cart);
                SessionsHelper.setobjectasjson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Carrito");
        }
        [HttpGet]
        public IActionResult Quitar(string id)
        {
            var cart = SessionsHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "cart");
            int index = Exist(cart, id);
            cart.RemoveAt(index);
            TempData["Contar"] = ContarItems(cart);
            SessionsHelper.setobjectasjson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Carrito");
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
                    Imagen="/img/CamisetaTitularDeca.png"
                },
                new Producto
                {
                    NombreProducto="Camiseta Suplente",
                    Detalle="Camiseta Suplente de juego unisex",
                    Precio= 50000.00,
                    Imagen="/img/CamisetaSuplenteDeca.png"
                },
                new Producto
                {
                    NombreProducto="Short Titular",
                    Detalle="Short titular de juego unisex",
                    Precio= 25000.00,
                    Imagen="/img/ShortTitularDeca.png"
                },
                new Producto
                {
                    NombreProducto="Short Suplente",
                    Detalle="Short suplente Camiseta titular de juego unisex",
                    Precio= 25000.00,
                    Imagen="/img/ShortSuplenteDeca.png"
                },
                new Producto
                {
                    NombreProducto="Kit Matero",
                    Detalle="Termo y Mate del violeta",
                    Precio= 65000.00,
                    Imagen="/img/KitMateroDeca.png"
                },
                new Producto
                {
                    NombreProducto="Buzo Decaño",
                    Detalle="Buzo DCVD",
                    Precio= 80000.00,
                    Imagen="/img/BuzoDeca.png"
                },
                new Producto
                {
                    NombreProducto="Piluso",
                    Detalle="Piluso Vamos Violeta",
                    Precio= 20000.00,
                    Imagen="/img/PilusoDeca.png"
                },
                new Producto
                {
                    NombreProducto="Medias de futbol",
                    Detalle="Medias de futbol DCVD",
                    Precio= 10000.00,
                    Imagen="/img/MediasDeca.png"
                },
            };
        }
    }
}
