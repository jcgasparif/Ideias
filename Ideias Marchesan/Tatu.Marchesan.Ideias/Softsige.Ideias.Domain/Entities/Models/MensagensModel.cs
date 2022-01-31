using System;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public class MensagensModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short PrimeiraMensagem { get; set; }
        public short SegundaMensagem { get; set; }
        public short TerceiraMensagem { get; set; }
        public int MotivoMensagemId { get; set; }

        public virtual MotivoMensagensModel MotivoMensagem { get; set; }
    }
}