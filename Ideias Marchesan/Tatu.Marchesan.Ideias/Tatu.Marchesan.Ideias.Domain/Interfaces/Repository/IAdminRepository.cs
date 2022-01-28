using System.Collections.Generic;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Domain.Interfaces.Repository
{
    public interface IAdminRepository : IRepository<RoleClaimModel>
    {
        Task<IEnumerable<RoleClaimModel>> GetClaimsValueByRoleName(string roleName);

        Task<IEnumerable<string>> GetAllRole();
    }
}