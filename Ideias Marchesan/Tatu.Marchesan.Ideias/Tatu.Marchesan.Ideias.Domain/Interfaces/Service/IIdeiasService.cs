using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;

namespace Tatu.Marchesan.Ideias.Domain.Interfaces.Service
{
    public interface IIdeiasService : IIdeiasRepository, IService
    {
        Task<int> HabilitarSegundaAvaliacao(int ideiaId);
    }
}