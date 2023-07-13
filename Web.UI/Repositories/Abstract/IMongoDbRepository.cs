using Web.UI.Entities.MongoDb;

namespace Web.UI.Repositories.Abstract
{
    public interface IMongoDbRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAsync();

        Task<TEntity?> GetAsync(string id);
        Task CreateAsync(TEntity newEntity);
        Task UpdateAsync(string id, TEntity updatedEntity);
        Task RemoveAsync(string id);
    }
}
