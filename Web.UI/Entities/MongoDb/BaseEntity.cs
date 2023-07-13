using MongoDB.Bson.Serialization.Attributes;

namespace Web.UI.Entities.MongoDb
{
    public class BaseEntity
    {
        [BsonId]
        public string? Id { get; set; }
    }
}
