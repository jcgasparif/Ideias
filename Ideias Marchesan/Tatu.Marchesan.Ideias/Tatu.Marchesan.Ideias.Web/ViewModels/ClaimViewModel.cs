using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tatu.Marchesan.Ideias.App.ViewModels
{
    public class ClaimViewModel
    {
        public string UserId { get; set; }

        [DisplayName("Nome do módulo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Type { get; set; }

        [DisplayName("Permissões")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Value { get; set; }
    }
}