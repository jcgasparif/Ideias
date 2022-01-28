using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tatu.Marchesan.Ideias.App.ViewModels
{
    public class AnexosViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tipo de Evento")]
        public int EventoTipoId { get; set; }

        [Required]
        public int IdeiaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        public string Path { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Selecione um anexo")]
        [FromForm(Name = "AnexoIFormFile")]
        public IFormFile AnexoIFormFile { get; set; }
    }
}