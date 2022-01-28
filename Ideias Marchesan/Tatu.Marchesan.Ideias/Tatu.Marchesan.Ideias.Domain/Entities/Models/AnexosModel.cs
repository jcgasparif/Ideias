namespace Tatu.Marchesan.Ideias.Domain.Entities.Models
{
    public class AnexosModel : EntityModel<int>
    {
        public int EventoTipoId { get; set; }
        public int IdeiaId { get; set; }
        public string Descricao { get; set; }
        public string Path { get; set; }
        public byte[] Anexo { get; set; }

        public virtual EventoTipoModel EventoTipo { get; set; }
        public virtual IdeiasModel Ideia { get; set; }
    }
}