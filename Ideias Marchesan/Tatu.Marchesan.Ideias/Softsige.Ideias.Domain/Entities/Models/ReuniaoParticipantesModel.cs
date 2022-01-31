namespace Softsige.Ideias.Domain.Entities.Models
{
    public class ReuniaoParticipantesModel
    {
        public int Id { get; set; }
        public int ReuniaoId { get; set; }
        public string UsuarioId { get; set; }

        public virtual ReuniaoModel Reuniao { get; set; }
    }
}