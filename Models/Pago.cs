namespace VendingNEA_Backend.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string FormaPago { get; set; } = string.Empty;
        public int IdLiquidacion { get; set; }
    }
}