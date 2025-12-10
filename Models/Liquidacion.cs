namespace VendingNEA_Backend.Models
{
    public class Liquidacion
    {
        public int IdLiquidacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public int IdAcuerdo { get; set; }
    }
}