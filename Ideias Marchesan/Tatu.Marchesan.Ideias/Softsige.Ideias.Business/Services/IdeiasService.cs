using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Enums;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.Services.Services
{
    public sealed class IdeiasService : IIdeiasService
    {
        private readonly IIdeiasRepository _ideiasRepository;

        public IdeiasService(IIdeiasRepository repository)
        {
            _ideiasRepository = repository;
        }

        public async Task<int> Add(IdeiasModel item)
        {
            return await _ideiasRepository.Add(item);
        }

        public async Task<int> Update(IdeiasModel item)
        {
            return await _ideiasRepository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _ideiasRepository.Delete(id);
        }

        public async Task<int> Delete(IdeiasModel item)
        {
            return await _ideiasRepository.Delete(item);
        }

        public async Task<IEnumerable<IdeiasModel>> FindAll()
        {
            return await _ideiasRepository.FindAll();
        }

        public async Task<IdeiasModel> FindById(int id)
        {
            return await _ideiasRepository.FindById(id);
        }

        public Task<int> SaveChanges()
        {
            return _ideiasRepository.SaveChanges();
        }

        public async Task<IdeiasModel> GetIdeiasAnexoById(int id)
        {
            return await _ideiasRepository.GetIdeiasAnexoById(id);
        }

        public async Task<IEnumerable<IdeiasModel>> GetAllIdeiasFiltro()
        {
            return await _ideiasRepository.GetAllIdeiasFiltro();
        }

        public async Task<ReuniaoModel> GetIdeiasReuniaoByIdeiaId(int id)
        {
            var model = await _ideiasRepository.GetIdeiasReuniaoByIdeiaId(id);

            return model;
        }

        public IEnumerable GetStatusList()
        {
            return _ideiasRepository.GetStatusList();
        }

        public IEnumerable GetEventoTipoList()
        {
            return _ideiasRepository.GetEventoTipoList();
        }

        public int GetCount()
        {
            return _ideiasRepository.GetCount();
        }

        public int GetNumIdeiasEmCriacao()
        {
            return _ideiasRepository.GetNumIdeiasEmCriacao();
        }

        public async Task<int> HabilitarSegundaAvaliacao(int ideiaId)
        {
            var model = await _ideiasRepository.FindById(ideiaId);
            model.StatusId = (int)AvaliacaoEnum.SegundaAvaliacao;

            return await _ideiasRepository.Update(model);
        }

        public void Dispose()
        {
            _ideiasRepository?.Dispose();
        }
    }
}