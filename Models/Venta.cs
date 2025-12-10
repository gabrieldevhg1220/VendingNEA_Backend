namespace VendingNEA_Backend.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaHora { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal MontoRecibido { get; set; }
        public int IdVisita { get; set; }
        public int IdMaquina { get; set; }
        public int IdProducto { get; set; }
    }
}