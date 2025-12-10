using System.ComponentModel.DataAnnotations.Schema;

namespace VendingNEA_Backend.Models
{
    [Table("REPOSITOR")]
    public class Repositor
    {
        [Column("legajo")]
        public int Legajo { get; set; }

        [Column("categoria_licencia")]
        public string CategoriaLicencia { get; set; } = string.Empty;

        [Column("turno")]
        public string Turno { get; set; } = string.Empty;

        [Column("zona_asignada")]
        public string ZonaAsignada { get; set; } = string.Empty;

        // Navegación para poder hacer Include
        public Empleado Empleado { get; set; } = null!;
    }
}