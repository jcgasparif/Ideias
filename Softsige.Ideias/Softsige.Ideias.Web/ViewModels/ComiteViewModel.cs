using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Softsige.Ideias.App.ViewModels
{
    public class ComiteViewModel
    {
        [Key]
        public int Id { get; set; }

        public int IdeiaId { get; set; }

        [DisplayName("Análise")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }

        [DisplayName("Relevância")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RelevanciaId { get; set; }

        public DateTime DataAnalise { get; set; }
        public string AspNetUsersId { get; set; }
        public string UserName { get; set; }

        public IdeiasViewModel Ideia { get; set; }
    }
}