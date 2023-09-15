using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogos
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo obrigatorio")]
        public string? Nome { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatorio")]
        public string? Descricao { get; set; }
        
        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Data Obrigatorioa")]
        public DateTime Datalancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "preco do jogo obrigatorio")]
        public decimal preco { get; set; }
        [Required(ErrorMessage = "informe o estudio que produziu")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
