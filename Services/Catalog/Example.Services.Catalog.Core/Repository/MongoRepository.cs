using Example.Services.Catalog.Domain.Models.Entities.Base;
using Example.Services.Catalog.Domain.Models.Settings;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Example.Services.Catalog.Core.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : MongoEntity, new()
    {
        #region Fields
        private readonly IMongoCollection<T> Collection;
        private readonly IDatabaseSettings _settings;
        #endregion

        #region Ctor
        public MongoRepository(IDatabaseSettings settings)
        {
            _settings = settings;
            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.DatabaseName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
        #endregion

        #region Methods
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public virtual async Task<T> UpdateAsync(string id, T entity)
        {
            return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await Collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.FindOneAndDeleteAsync(filter);
        }

        public virtual async void DeleteAllAsync(Expression<Func<T, bool>> filter)
        {
            await Collection.DeleteManyAsync(filter);
        }
        #endregion
    }
}
