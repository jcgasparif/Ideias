using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Infrastructure.Context;

namespace Tatu.Marchesan.Ideias.Infrastructure.Repository
{
    public class AdminRepository : Repository<RoleClaimModel>, IAdminRepository
    {
        private readonly MarchesanIdeiasDbContext _context;

        public AdminRepository(MarchesanIdeiasDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleClaimModel>> GetClaimsValueByRoleName(string roleName)
        {
            var result = await _context.RoleClaim
                .Where(x => x.RoleName == roleName)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<string>> GetAllRole()
        {
            var result = await _context.RoleClaim
                .Select(x => x.RoleName)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}