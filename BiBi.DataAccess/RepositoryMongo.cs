using BiBi.Domain;
using BiBi.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BiBi.DataAccess
{
    /// <summary>
    /// GENERIC REPOSITORY USING C# MONGODB DRIVER
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryMongo<TEntity> where TEntity : IMongoEntity
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<TEntity> _collection;

        public RepositoryMongo()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("Domain");
            //  .CONFIG :  ConfigurationManager.AppSettings["MongoServer"]
            //  App.Config XML  :   <appSettings> <add Key...
            //  OR VS Proj -> Properties -> .settings



            BsonClassMap.RegisterClassMap<TEntity>(e =>
            {
                e.AutoMap();
                e.MapIdProperty(u => u.ObjectID)
                   .SetIdGenerator(StringObjectIdGenerator.Instance)
                   .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            //  https://jira.mongodb.org/browse/CSHARP-398
            //  Inherit from abstract class so wouldn't have to be implemented by models.
            //  IMongoEntity (interface) -> MongoEntityBase (abstract class)
            /*
                 BsonClassMap.RegisterClassMap<BaseOfMyClass>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIdMember(cm.GetMemberMap(c => c.Id));
                });
                BsonClassMap.RegisterClassMap<MyClass>();
             */


            _collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria)
        {
            List<TEntity> entities = new List<TEntity>();

            Task.Run(async () =>
            {
                entities = await _collection.Find(criteria).ToListAsync();
            }).GetAwaiter().GetResult();

            return entities;
        }

        public List<TEntity> GetAll()
        {
            return this.GetAll(_ => true);
        }

        public TEntity Add(TEntity entity)
        {
            Task.Run(async () =>
            {
                await _collection.InsertOneAsync(entity);
            }).GetAwaiter().GetResult();
            return entity;
        }
    }
}
