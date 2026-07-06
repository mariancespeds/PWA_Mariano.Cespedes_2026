using System.ComponentModel.DataAnnotations;

namespace SitioWebPwa.Models
{
    public class Producto
    {
        [Key]
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Detalle { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public int Cantidad { get; set; }
    }
    public class ProductosVM
    {
        public IEnumerable<Producto> productos { get; set; }
    }
}
