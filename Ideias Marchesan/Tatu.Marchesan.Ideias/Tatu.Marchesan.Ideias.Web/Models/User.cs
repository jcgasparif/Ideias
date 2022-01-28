using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tatu.Marchesan.Ideias.App.Models
{
    public class User
    {
        [DisplayName("Nome do usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não é válido!")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Password { get; set; }
    }
}