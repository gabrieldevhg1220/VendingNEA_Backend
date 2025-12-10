namespace VendingNEA_Backend.Models
{
    public class Incidente
    {
        public int IdIncidente { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoFalla { get; set; }
        public DateTime FechaReporte { get; set; }
        public string? Estado { get; set; }
        public int IdMaquina { get; set; }
        public int LegajoEmpleado { get; set; }
    }
}