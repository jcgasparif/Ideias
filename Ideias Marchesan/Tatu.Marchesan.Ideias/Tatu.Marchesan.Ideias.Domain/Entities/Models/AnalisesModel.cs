using System;

namespace Tatu.Marchesan.Ideias.Domain.Entities.Models
{
    public class AnalisesModel : EntityModel<int>
    {
        public int IdeiaId { get; set; }
        public string Descricao { get; set; }
        public int RelevanciaId { get; set; }
        public DateTime DataAnalise { get; set; }
        public string AspNetUsersId { get; set; }

        public int SequenciaAnalise { get; set; }

        public virtual IdeiasModel Ideia { get; set; }
        public virtual RelevanciasModel Relevancia { get; set; }
    }
}