namespace VendingNEA_Backend.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Patente { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaUltimoMantenimiento { get; set; }
    }
}