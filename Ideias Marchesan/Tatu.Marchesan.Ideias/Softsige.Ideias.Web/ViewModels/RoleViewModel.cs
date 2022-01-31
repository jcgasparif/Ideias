using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Softsige.Ideias.App.ViewModels
{
    public class RoleViewModel
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserId { get; set; }

        [DisplayName("RoleID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Id { get; set; }

        [DisplayName("Nome da Role")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}