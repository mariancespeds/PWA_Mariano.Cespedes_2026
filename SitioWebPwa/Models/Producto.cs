namespace SitioWebPwa.Models
{
    public class Producto
    {
        public string NombreProducto { get; set; }
        public string Detalle { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
    }
    public class ProductosVM
    {
        public IEnumerable<Producto> productos { get; set; }
    }
}
