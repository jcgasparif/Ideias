using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Enums;

namespace Tatu.Marchesan.Ideias.App.ViewModels
{
    public class IdeiasViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Data de Inclusão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInclusao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Produto novo?")]
        public bool ProdutoNovo { get; set; }

        [DisplayName("Nome do Produto")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string ProdutoExistente { get; set; }

        [DisplayName("Produto concorrente?")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool ExisteConcorrente { get; set; }

        [DisplayName("Detalhes do concorrente")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string DetalhesConcorrente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Argumentos { get; set; }

        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data Envio para Análise")]
        public DateTime? DataSubAnalise { get; set; }

        [DisplayName("Status")]
        public StatusEnum StatusId { get; set; }

        public string AspNetUsersId { get; set; }

        public bool NovaIdeiaEmCriacao { get; set; }

        public StatusModel Status { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        public IEnumerable<AnexosModel> Anexos { get; set; }

        public IEnumerable<ReuniaoModel> Reuniao { get; set; }
    }
}