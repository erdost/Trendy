using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Trendy.Data;

namespace Trendy.Entities
{
    public class Product : EntityBase
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastUpdatedTime")]
        public DateTime LastUpdatedTime { get; set; }
    }
}
