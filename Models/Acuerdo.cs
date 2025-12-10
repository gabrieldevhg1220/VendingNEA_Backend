using System.ComponentModel.DataAnnotations.Schema;

namespace VendingNEA_Backend.Models
{
    [Table("ACUERDO")]
    public class Acuerdo
    {
        [Column("id_acuerdo")]
        public int IdAcuerdo { get; set; }

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Column("tipo_condicion")]
        public string TipoCondicion { get; set; } = string.Empty;

        [Column("valor_condicion")]
        public decimal ValorCondicion { get; set; }

        [Column("id_establecimiento")]
        public int IdEstablecimiento { get; set; }
    }
}