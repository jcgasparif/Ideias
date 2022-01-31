using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.Services.Services
{
    public sealed class AnexosService : IAnexosService
    {
        private readonly IAnexosRepository _anexosRepository;

        public AnexosService(IAnexosRepository repository)
        {
            _anexosRepository = repository;
        }

        public async Task<int> Add(AnexosModel item)
        {
            return await _anexosRepository.Add(item);
        }

        public async Task<int> Update(AnexosModel item)
        {
            return await _anexosRepository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _anexosRepository.Delete(id);
        }

        public async Task<int> Delete(AnexosModel item)
        {
            return await _anexosRepository.Delete(item);
        }

        public async Task<IEnumerable<AnexosModel>> FindAll()
        {
            return await _anexosRepository.FindAll();
        }

        public async Task<AnexosModel> FindById(int id)
        {
            return await _anexosRepository.FindById(id);
        }

        public Task<int> SaveChanges()
        {
            return _anexosRepository.SaveChanges();
        }

        public void Dispose()
        {
            _anexosRepository?.Dispose();
        }
    }
}