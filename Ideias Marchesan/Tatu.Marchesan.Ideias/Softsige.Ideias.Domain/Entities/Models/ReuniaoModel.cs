using System;
using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public sealed class ReuniaoModel
    {
        public ReuniaoModel()
        {
            ReuniaoParticipantes = new HashSet<ReuniaoParticipantesModel>();
        }

        public int Id { get; set; }
        public int IdeiaId { get; set; }
        public DateTime Data { get; set; }

        public IdeiasModel Ideia { get; set; }
        public ICollection<ReuniaoParticipantesModel> ReuniaoParticipantes { get; set; }
    }
}