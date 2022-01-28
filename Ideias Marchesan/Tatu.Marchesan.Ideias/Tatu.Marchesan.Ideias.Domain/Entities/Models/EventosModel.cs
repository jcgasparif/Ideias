using System;

namespace Tatu.Marchesan.Ideias.Domain.Entities.Models
{
    public class EventosModel
    {
        public int Id { get; set; }
        public int EventoTipoId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int Origem { get; set; }

        public virtual EventoTipoModel EventoTipo { get; set; }
    }
}