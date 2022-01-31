using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Infrastructure.Context;

namespace Softsige.Ideias.Infrastructure.Repository
{
    public class AnexosRepository : Repository<AnexosModel>, IAnexosRepository
    {
        public AnexosRepository(MarchesanIdeiasDbContext context) : base(context)
        {
        }
    }
}