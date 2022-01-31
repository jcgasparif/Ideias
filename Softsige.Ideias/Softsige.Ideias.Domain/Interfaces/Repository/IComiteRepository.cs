using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Domain.Interfaces.Repository
{
    public interface IComiteRepository : IRepository<AnalisesModel>
    {
        Task<IEnumerable<AnalisesModel>> GetComiteIdeias();

        Task<IEnumerable> GetRelevanciaList();

        Task<int> CriaReuniaoComite(int ideiaId, DateTime dataHoraReuniao);

        Task<List<AvaliacoesModel>> GetListaAvaliacoes(int ideiaId);
    }
}