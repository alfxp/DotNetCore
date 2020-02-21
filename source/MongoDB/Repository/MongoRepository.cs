using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.MongoDB
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly MongoCommandRepository<T> _mongoCommandRepository;
        private readonly MongoQueryRepository<T> _mongoQueryRepository;

        public MongoRepository(IMongoContext context)
        {
            _mongoCommandRepository = new MongoCommandRepository<T>(context);
            _mongoQueryRepository = new MongoQueryRepository<T>(context);
        }

        public IQueryable<T> Queryable => _mongoQueryRepository.Queryable;

        public void Add(T item)
        {
            _mongoCommandRepository.Add(item);
        }

        public Task AddAsync(T item)
        {
            return _mongoCommandRepository.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _mongoCommandRepository.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return _mongoCommandRepository.AddRangeAsync(items);
        }

        public bool Any()
        {
            return _mongoQueryRepository.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _mongoQueryRepository.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return _mongoQueryRepository.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return _mongoQueryRepository.AnyAsync(where);
        }

        public long Count()
        {
            return _mongoQueryRepository.Count();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return _mongoQueryRepository.Count(where);
        }

        public Task<long> CountAsync()
        {
            return _mongoQueryRepository.CountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return _mongoQueryRepository.CountAsync(where);
        }

        public void Delete(object key)
        {
            _mongoCommandRepository.Delete(key);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            _mongoCommandRepository.Delete(where);
        }

        public Task DeleteAsync(object key)
        {
            return _mongoCommandRepository.DeleteAsync(key);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return _mongoCommandRepository.DeleteAsync(where);
        }

        public T Get(object key)
        {
            return _mongoQueryRepository.Get(key);
        }

        public Task<T> GetAsync(object key)
        {
            return _mongoQueryRepository.GetAsync(key);
        }

        public IEnumerable<T> List()
        {
            return _mongoQueryRepository.List();
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return _mongoQueryRepository.ListAsync();
        }

        public IQueryable<T> Specify(ISpecification<T> specification)
        {
            return _mongoQueryRepository.Specify(specification);
        }

        public Task<IQueryable<T>> SpecifyAsync(ISpecification<T> specification)
        {
            return _mongoQueryRepository.SpecifyAsync(specification);
        }

        public void Update(object key, T item)
        {
            _mongoCommandRepository.Update(key, item);
        }

        public Task UpdateAsync(object key, T item)
        {
            return _mongoCommandRepository.UpdateAsync(key, item);
        }

        public void UpdatePartial(object key, object item)
        {
            _mongoCommandRepository.UpdatePartial(key, item);
        }

        public Task UpdatePartialAsync(object key, object item)
        {
            return _mongoCommandRepository.UpdatePartialAsync(key, item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _mongoCommandRepository.UpdateRange(items);
        }

        public Task UpdateRangeAsync(IEnumerable<T> items)
        {
            return _mongoCommandRepository.UpdateRangeAsync(items);
        }
    }
}
