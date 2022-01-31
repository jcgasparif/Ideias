namespace Softsige.Ideias.Domain.Entities.Models
{
    public class AvaliacoesModel
    {
        public int IdeiaId { get; set; }

        public string AvaliadorId { get; set; }

        public string AvaliadorNome { get; set; }

        public bool PrimeiraAnalise { get; set; }

        public bool SegundaAnalise { get; set; }

        public int EmailPrimeiraAnalise { get; set; }

        public int EmailSegundaAnalise { get; set; }
    }
}