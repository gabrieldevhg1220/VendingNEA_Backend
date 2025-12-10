namespace VendingNEA_Backend.Models
{
    public class Ruta
    {
        public int IdRuta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdVehiculo { get; set; }
        public int LegajoRepositor { get; set; }
    }
}