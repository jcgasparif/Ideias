using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public sealed class RelevanciasModel : EntityModel<int>
    {
        public RelevanciasModel()
        {
            Analises = new HashSet<AnalisesModel>();
        }

        public string Descricao { get; set; }
        public int Peso { get; set; }

        public ICollection<AnalisesModel> Analises { get; set; }
    }
}