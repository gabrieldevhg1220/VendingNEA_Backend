using System.ComponentModel.DataAnnotations.Schema;

namespace VendingNEA_Backend.Models
{
    [Table("EMPLEADO")]
    public class Empleado
    {
        [Column("legajo")]
        public int Legajo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Column("dni")]
        public string Dni { get; set; } = string.Empty;

        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get; set; }
    }
}