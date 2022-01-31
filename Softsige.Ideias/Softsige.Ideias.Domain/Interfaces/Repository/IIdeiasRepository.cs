using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Domain.Interfaces.Repository
{
    public interface IIdeiasRepository : IRepository<IdeiasModel>
    {
        Task<IdeiasModel> GetIdeiasAnexoById(int id);

        Task<IEnumerable<IdeiasModel>> GetAllIdeiasFiltro();

        IEnumerable GetStatusList();

        IEnumerable GetEventoTipoList();

        int GetCount();

        int GetNumIdeiasEmCriacao();

        Task<ReuniaoModel> GetIdeiasReuniaoByIdeiaId(int id);
    }
}