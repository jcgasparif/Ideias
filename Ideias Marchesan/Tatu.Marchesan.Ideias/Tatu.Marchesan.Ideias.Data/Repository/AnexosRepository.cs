using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Infrastructure.Context;

namespace Tatu.Marchesan.Ideias.Infrastructure.Repository
{
    public class AnexosRepository : Repository<AnexosModel>, IAnexosRepository
    {
        public AnexosRepository(MarchesanIdeiasDbContext context) : base(context)
        {
        }
    }
}