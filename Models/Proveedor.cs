namespace VendingNEA_Backend.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Cuit { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}