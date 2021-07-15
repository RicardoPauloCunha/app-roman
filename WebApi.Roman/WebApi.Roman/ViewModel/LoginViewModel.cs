using System.ComponentModel.DataAnnotations;

namespace Senai.Sprint5.Exercicio.Roman.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(40,MinimumLength = 5)]
        public string Senha { get; set; }
    }
}
