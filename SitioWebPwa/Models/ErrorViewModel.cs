namespace SitioWebPwa.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Valores
    {
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Detalle { get; set; }
    }
    public class ValoresVM
    {
        public IEnumerable<Valores> valores { get; set; }
    }
}
