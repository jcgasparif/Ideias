using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Infrastructure.Context;

namespace Softsige.Ideias.Infrastructure.Repository
{
    public class RelevanciaRepository : Repository<RelevanciasModel>, IRelevanciaRepository
    {
        public RelevanciaRepository(MarchesanIdeiasDbContext context) : base(context)
        {
        }
    }
}