using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web.UI.Configuration;
using Web.UI.Entities.MongoDb;
using Web.UI.Models;
using Web.UI.Repositories.Abstract;

namespace Web.UI.Services
{
    public class TahtaService
    {
        private readonly IMongoDbRepository<TahtaEntity> _tahtaRepository;

        public TahtaService(IMongoDbRepository<TahtaEntity> tahtaRepository)
        {
            _tahtaRepository = tahtaRepository;
        }

        public async Task<List<TahtaEntity>> GetAsync() =>
            await _tahtaRepository.GetAsync();

        public async Task<TahtaEntity> GetAsync(string id) => 
            await _tahtaRepository.GetAsync(id);
 

        public async Task CreateAsync(TahtaEntity newTahta) => 
            await _tahtaRepository.CreateAsync(newTahta);


        public async Task UpdateAsync(string id, TahtaEntity updatedTahta) =>
            await _tahtaRepository.UpdateAsync(id, updatedTahta);


        public async Task DeleteAsync(string id) => 
            await _tahtaRepository.RemoveAsync(id);
    }
}
