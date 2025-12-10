namespace VendingNEA_Backend.Models
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public int IdRuta { get; set; }
        public int IdMaquina { get; set; }
        public int LegajoRepositor { get; set; }
    }
}