using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tatu.Marchesan.Ideias.App.Models
{
    public class ResetPassword
    {
        [Required]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "A senha e confirmação de senha não são iguais!")]
        [DisplayName("Confirmação de Senha")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}