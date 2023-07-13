using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web.UI.Configuration;
using Web.UI.Entities.MongoDb;
using Web.UI.Models;
using Web.UI.Repositories.Abstract;

namespace Web.UI.Repositories.Concrete
{
    public class MongoDbRepository<TEntity>: IMongoDbRepository<TEntity> where TEntity: BaseEntity
    {
        private readonly IMongoCollection<TEntity> _entityCollection;

        public MongoDbRepository(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _entityCollection = mongoDatabase.GetCollection<TEntity>(
                databaseSettings.Value.CollectionName);
        }

        public async Task<List<TEntity>> GetAsync() =>
            await _entityCollection.Find(_ => true).ToListAsync();

        public async Task<TEntity?> GetAsync(string id) =>
            await _entityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TEntity newEntity) =>
            await _entityCollection.InsertOneAsync(newEntity);

        public async Task UpdateAsync(string id, TEntity updatedEntity) =>
            await _entityCollection.ReplaceOneAsync(x => x.Id == id, updatedEntity);

        public async Task RemoveAsync(string id) =>
            await _entityCollection.DeleteOneAsync(x => x.Id == id);
    }
}
