using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Trendy.Data
{
    public class MongoRepository<Entity> : IRepository<Entity> where Entity : EntityBase
    {
        const string mongoDbName = "Trendy";

        const string mongoConnectionString = "mongodb://mongodb:27017";

        IMongoCollection<Entity> _collection;

        public MongoRepository()
        {
            IMongoDatabase mongodb = new MongoClient(mongoConnectionString).GetDatabase(mongoDbName);

            // Collection names are plural form of the entity names
            _collection = mongodb.GetCollection<Entity>(typeof(Entity).Name + "s");
        }

        public IList<Entity> SearchFor(Expression<Func<Entity, bool>> predicate, int pageSize, int pageIndex)
        {
            return _collection.AsQueryable<Entity>().Where(predicate.Compile())
                .Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }
    }
}
