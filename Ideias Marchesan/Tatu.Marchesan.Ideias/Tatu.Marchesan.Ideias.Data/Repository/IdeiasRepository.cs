using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Infrastructure.Context;

namespace Tatu.Marchesan.Ideias.Infrastructure.Repository
{
    public class IdeiasRepository : Repository<IdeiasModel>, IIdeiasRepository
    {
        private readonly MarchesanIdeiasDbContext _context;

        public IdeiasRepository(MarchesanIdeiasDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IdeiasModel> GetIdeiasAnexoById(int id)
        {
            var result = await _context.Ideias
                .Where(x => x.Id == id)
                .Include("Anexos")
                .Include("Status")
                .Include("Reuniao")
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<IdeiasModel>> GetAllIdeiasFiltro()
        {
            var result = await _context.Ideias
                .Select(x => new IdeiasModel
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    DataInclusao = x.DataInclusao,
                    AspNetUsersId = x.AspNetUsersId,
                    StatusId = x.StatusId
                })
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<ReuniaoModel> GetIdeiasReuniaoByIdeiaId(int id)
        {
            var result = await _context.Reuniao
                .Where(x => x.IdeiaId == id)
                .Include("ReuniaoParticipantes")
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public IEnumerable GetStatusList()
        {
            return _context.Status;
        }

        public IEnumerable GetEventoTipoList()
        {
            return _context.EventoTipo;
        }

        public int GetCount()
        {
            return _context.Ideias.Count();
        }

        public int GetNumIdeiasEmCriacao()
        {
            return _context.Ideias.Count(x => x.NovaIdeiaEmCriacao);
        }
    }
}