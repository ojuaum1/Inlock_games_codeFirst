using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.inlock.codeFirst.manha.Domain;

namespace WEBAPI.inlock_CodeFirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuarios
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome oBrigatorio!")]

        public string titulo { get; set;  }

     
    }
}
