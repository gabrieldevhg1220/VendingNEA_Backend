namespace VendingNEA_Backend.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodProducto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime FechaVencimiento { get; set; }
        public decimal Precio { get; set; }
    }
}