using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trendy.Data
{
    public class EntityBase
    {
        public ObjectId Id { get; set; }
    }
}
