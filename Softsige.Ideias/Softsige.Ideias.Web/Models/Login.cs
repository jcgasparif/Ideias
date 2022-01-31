using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Softsige.Ideias.App.Models
{
    public class Login
    {
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Usuário")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}