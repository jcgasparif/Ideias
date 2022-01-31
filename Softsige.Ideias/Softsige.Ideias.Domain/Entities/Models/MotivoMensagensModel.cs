using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public sealed class MotivoMensagensModel
    {
        public MotivoMensagensModel()
        {
            Mensagens = new HashSet<MensagensModel>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<MensagensModel> Mensagens { get; set; }
    }
}