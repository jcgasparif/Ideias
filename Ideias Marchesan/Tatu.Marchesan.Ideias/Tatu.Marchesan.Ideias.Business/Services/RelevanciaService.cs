using System.Collections.Generic;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.Services.Services
{
    public sealed class RelevanciaService : IRelevanciaService
    {
        private readonly IRelevanciaRepository _relevanciaRepository;

        public RelevanciaService(IRelevanciaRepository repository)
        {
            _relevanciaRepository = repository;
        }

        public async Task<int> Add(RelevanciasModel item)
        {
            return await _relevanciaRepository.Add(item);
        }

        public async Task<int> Update(RelevanciasModel item)
        {
            return await _relevanciaRepository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _relevanciaRepository.Delete(id);
        }

        public async Task<int> Delete(RelevanciasModel item)
        {
            return await _relevanciaRepository.Delete(item);
        }

        public async Task<IEnumerable<RelevanciasModel>> FindAll()
        {
            return await _relevanciaRepository.FindAll();
        }

        public async Task<RelevanciasModel> FindById(int id)
        {
            return await _relevanciaRepository.FindById(id);
        }

        public Task<int> SaveChanges()
        {
            return _relevanciaRepository.SaveChanges();
        }

        public void Dispose()
        {
            _relevanciaRepository?.Dispose();
        }
    }
}