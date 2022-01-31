using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public sealed class EventoTipoModel
    {
        public EventoTipoModel()
        {
            Anexos = new HashSet<AnexosModel>();
            Eventos = new HashSet<EventosModel>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<AnexosModel> Anexos { get; set; }
        public ICollection<EventosModel> Eventos { get; set; }
    }
}