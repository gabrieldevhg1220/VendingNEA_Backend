namespace VendingNEA_Backend.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public int IdProveedor { get; set; }
    }
}