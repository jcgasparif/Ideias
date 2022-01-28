using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.Services.Services
{
    public sealed class ComiteService : IComiteService
    {
        private readonly IComiteRepository _comiteRepository;

        public ComiteService(IComiteRepository repository)
        {
            _comiteRepository = repository;
        }

        public async Task<int> Add(AnalisesModel item)
        {
            return await _comiteRepository.Add(item);
        }

        public async Task<int> Update(AnalisesModel item)
        {
            return await _comiteRepository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _comiteRepository.Delete(id);
        }

        public async Task<int> Delete(AnalisesModel item)
        {
            return await _comiteRepository.Delete(item);
        }

        public async Task<IEnumerable<AnalisesModel>> FindAll()
        {
            return await _comiteRepository.FindAll();
        }

        public async Task<AnalisesModel> FindById(int id)
        {
            return await _comiteRepository.FindById(id);
        }

        public Task<int> SaveChanges()
        {
            return _comiteRepository.SaveChanges();
        }

        public async Task<IEnumerable<AnalisesModel>> GetComiteIdeias()
        {
            return await _comiteRepository.GetComiteIdeias();
        }

        public async Task<int> CriaReuniaoComite(int ideiaId, DateTime dataHoraReuniao)
        {
            return await _comiteRepository.CriaReuniaoComite(ideiaId, dataHoraReuniao);
        }

        public async Task<IEnumerable> GetRelevanciaList()
        {
            return await _comiteRepository.GetRelevanciaList();
        }

        public async Task<List<AvaliacoesModel>> GetListaAvaliacoes(int ideiaId)
        {
            return await _comiteRepository.GetListaAvaliacoes(ideiaId);
        }

        public void Dispose()
        {
            _comiteRepository?.Dispose();
        }
    }
}