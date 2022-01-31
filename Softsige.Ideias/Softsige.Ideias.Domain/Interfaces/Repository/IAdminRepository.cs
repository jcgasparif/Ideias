using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Domain.Interfaces.Repository
{
    public interface IAdminRepository : IRepository<RoleClaimModel>
    {
        Task<IEnumerable<RoleClaimModel>> GetClaimsValueByRoleName(string roleName);

        Task<IEnumerable<string>> GetAllRole();
    }
}