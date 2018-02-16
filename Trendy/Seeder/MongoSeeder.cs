using Dapper;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trendy.Entities;

namespace Trendy.Seeder
{
    public class MongoSeeder
    {
        const string mongoConnectionString = "mongodb://mongodb:27017";

        const string dbConnectionString = @"Server=mssql;Database=Trendy;User=sa;Password=yourStrong(!)Password";

        const string mongoDbName = "Trendy";

        const string collectionName = "Products";

        readonly IMongoDatabase _mongodb;

        public MongoSeeder()
        {
            _mongodb = new MongoClient(mongoConnectionString).GetDatabase(mongoDbName);
        }

        public async Task ImportJson(string inputFileName)
        {
            var collection = _mongodb.GetCollection<Product>(collectionName);

            string text = File.ReadAllText(inputFileName);

            var products = BsonSerializer.Deserialize<List<Product>>(text);

            await collection.InsertManyAsync(products);
        }

        //public void SyncMongo()
        //{
        //    List<Product> allProducts;

        //    using (IDbConnection db = new SqlConnection(dbConnectionString))
        //    {
        //        allProducts = db.Query<Product>("Select * From Products").ToList();
        //    }

        //    var collection = _mongodb.GetCollection<Product>(collectionName);

        //    collection.InsertMany(allProducts);
        //}
    }
}
