using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tatu.Marchesan.Ideias.App.ViewModels
{
    public class AvaliacoesViewModel
    {
        [Key]
        public int Id { get; set; }

        public int IdeiaId { get; set; }
        public string AvaliadorId { get; set; }

        [DisplayName("Nome Avaliador")]
        public string AvaliadorNome { get; set; }

        [DisplayName("1ª Analise")]
        public bool PrimeiraAnalise { get; set; }

        [DisplayName("2ª Analise")]
        public bool SegundaAnalise { get; set; }

        [DisplayName("QT E-mail 1ª Analise")]
        public int EmailPrimeiraAnalise { get; set; }

        [DisplayName("QT E-mail 2ª Analise")]
        public int EmailSegundaAnalise { get; set; }
    }
}