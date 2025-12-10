namespace VendingNEA_Backend.Models
{
    public class Establecimiento
    {
        public int IdEstablecimiento { get; set; }
        public string Cuit { get; set; } = string.Empty;
        public string NombreComercial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string TipoLugar { get; set; } = string.Empty;
        public string UbicacionInterna { get; set; } = string.Empty;
    }
}