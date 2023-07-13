using MongoDB.Bson.Serialization.Attributes;

namespace Web.UI.Entities.MongoDb
{
    public class TahtaEntity: BaseEntity
    {
        [BsonElement("Kareler")]
        public string Kareler { get; set; }
    }
}
