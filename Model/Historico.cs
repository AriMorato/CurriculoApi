using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurriculoApi.Model
{
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Curriculo")]
        public int IdCurriculo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(200)]
        public string Detalhes { get; set; } = String.Empty;
    }
}
