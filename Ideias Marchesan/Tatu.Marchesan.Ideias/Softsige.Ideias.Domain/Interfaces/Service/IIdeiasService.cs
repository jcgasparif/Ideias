using System.Threading.Tasks;
using Softsige.Ideias.Domain.Interfaces.Repository;

namespace Softsige.Ideias.Domain.Interfaces.Service
{
    public interface IIdeiasService : IIdeiasRepository, IService
    {
        Task<int> HabilitarSegundaAvaliacao(int ideiaId);
    }
}