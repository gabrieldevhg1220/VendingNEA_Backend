namespace VendingNEA_Backend.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Costo { get; set; }
        public int IdMaquina { get; set; }
        public int LegajoTecnico { get; set; }
    }
}