using System.ComponentModel.DataAnnotations;

namespace WEBAPI.inlock_CodeFirst.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage ="email obrigatorio!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "senha obrigatoria!")]
        public string? Senha { get; set; }
    }
}
