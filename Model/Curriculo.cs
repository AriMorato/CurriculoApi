using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurriculoApi.Model
{
    public class Curriculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string SobreNome { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(60)]
        public string Cargo { get; set; }

        [Required]
        public float Remuneracao { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime DataEnvio { get; set; }

        [Required]
        public byte[] Arquivo { get; set; }
    }
}
