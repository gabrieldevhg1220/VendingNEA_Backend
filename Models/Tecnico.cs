using System.ComponentModel.DataAnnotations.Schema;

namespace VendingNEA_Backend.Models
{
    [Table("TECNICO")]
    public class Tecnico
    {
        [Column("legajo")]
        public int Legajo { get; set; }

        [Column("especialidad")]
        public string Especialidad { get; set; } = string.Empty;

        [Column("nivel_certificacion")]
        public string NivelCertificacion { get; set; } = string.Empty;

        // Navegación para poder hacer Include
        public Empleado Empleado { get; set; } = null!;
    }
}