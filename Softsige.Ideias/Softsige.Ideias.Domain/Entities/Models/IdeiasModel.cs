using System;
using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public sealed class IdeiasModel : EntityModel<int>
    {
        public IdeiasModel()
        {
            Analises = new HashSet<AnalisesModel>();
            Reuniao = new HashSet<ReuniaoModel>();
            Anexos = new HashSet<AnexosModel>();
        }

        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool ProdutoNovo { get; set; }
        public string ProdutoExistente { get; set; }
        public bool ExisteConcorrente { get; set; }
        public string DetalhesConcorrente { get; set; }
        public string Argumentos { get; set; }
        public DateTime? DataSubAnalise { get; set; }
        public int StatusId { get; set; }
        public string AspNetUsersId { get; set; }
        public bool NovaIdeiaEmCriacao { get; set; }

        public StatusModel Status { get; set; }
        public ICollection<AnalisesModel> Analises { get; set; }
        public ICollection<ReuniaoModel> Reuniao { get; set; }
        public ICollection<AnexosModel> Anexos { get; set; }
    }
}