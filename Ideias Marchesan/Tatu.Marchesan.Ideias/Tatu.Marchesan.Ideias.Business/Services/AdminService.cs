using System.Collections.Generic;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.Services.Services
{
    public sealed class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository repository)
        {
            _adminRepository = repository;
        }

        public Task<int> Add(RoleClaimModel item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(RoleClaimModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _adminRepository?.Dispose();
        }

        public Task<IEnumerable<RoleClaimModel>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<RoleClaimModel> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RoleClaimModel>> GetClaimsValueByRoleName(string roleName)
        {
            return await _adminRepository.GetClaimsValueByRoleName(roleName);
        }

        public Task<int> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(RoleClaimModel item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetAllRole()
        {
            return await _adminRepository.GetAllRole();
        }
    }
}