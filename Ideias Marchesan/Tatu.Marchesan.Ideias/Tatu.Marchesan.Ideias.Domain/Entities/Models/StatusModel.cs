using System.Collections.Generic;

namespace Tatu.Marchesan.Ideias.Domain.Entities.Models
{
    public sealed class StatusModel
    {
        public StatusModel()
        {
            Ideias = new HashSet<IdeiasModel>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoProcesso { get; set; }

        public ICollection<IdeiasModel> Ideias { get; set; }
    }
}