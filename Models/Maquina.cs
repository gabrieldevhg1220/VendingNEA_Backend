using System.ComponentModel.DataAnnotations.Schema;

namespace VendingNEA_Backend.Models
{
    [Table("MAQUINA")]
    public class Maquina
    {
        [Column("id_maquina")]
        public int IdMaquina { get; set; }

        [Column("nro_serie")]
        public string NroSerie { get; set; } = string.Empty;

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("marca")]
        public string Marca { get; set; } = string.Empty;

        [Column("modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Column("tipo_cobro")]
        public string TipoCobro { get; set; } = string.Empty;

        [Column("id_acuerdo")]
        public int IdAcuerdo { get; set; }
    }
}