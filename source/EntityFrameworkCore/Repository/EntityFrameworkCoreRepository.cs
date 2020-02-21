using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly EntityFrameworkCoreCommandRepository<T> _entityFrameworkCoreCommandRepository;
        private readonly EntityFrameworkCoreQueryRepository<T> _entityFrameworkCoreQueryRepository;

        public EntityFrameworkCoreRepository(DbContext context)
        {
            _entityFrameworkCoreCommandRepository = new EntityFrameworkCoreCommandRepository<T>(context);
            _entityFrameworkCoreQueryRepository = new EntityFrameworkCoreQueryRepository<T>(context);
        }

        public IQueryable<T> Queryable => _entityFrameworkCoreQueryRepository.Queryable;

        public void Add(T item)
        {
            _entityFrameworkCoreCommandRepository.Add(item);
        }

        public Task AddAsync(T item)
        {
            return _entityFrameworkCoreCommandRepository.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _entityFrameworkCoreCommandRepository.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return _entityFrameworkCoreCommandRepository.AddRangeAsync(items);
        }

        public bool Any()
        {
            return _entityFrameworkCoreQueryRepository.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _entityFrameworkCoreQueryRepository.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return _entityFrameworkCoreQueryRepository.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return _entityFrameworkCoreQueryRepository.AnyAsync(where);
        }

        public long Count()
        {
            return _entityFrameworkCoreQueryRepository.Count();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return _entityFrameworkCoreQueryRepository.Count(where);
        }

        public Task<long> CountAsync()
        {
            return _entityFrameworkCoreQueryRepository.CountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return _entityFrameworkCoreQueryRepository.CountAsync(where);
        }

        public void Delete(object key)
        {
            _entityFrameworkCoreCommandRepository.Delete(key);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            _entityFrameworkCoreCommandRepository.Delete(where);
        }

        public Task DeleteAsync(object key)
        {
            return _entityFrameworkCoreCommandRepository.DeleteAsync(key);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return _entityFrameworkCoreCommandRepository.DeleteAsync(where);
        }

        public T Get(object key)
        {
            return _entityFrameworkCoreQueryRepository.Get(key);
        }

        public Task<T> GetAsync(object key)
        {
            return _entityFrameworkCoreQueryRepository.GetAsync(key);
        }

        public IEnumerable<T> List()
        {
            return _entityFrameworkCoreQueryRepository.List();
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return _entityFrameworkCoreQueryRepository.ListAsync();
        }

        public IQueryable<T> Specify(ISpecification<T> specification)
        {
            return _entityFrameworkCoreQueryRepository.Specify(specification);
        }

        public Task<IQueryable<T>> SpecifyAsync(ISpecification<T> specification)
        {
            return _entityFrameworkCoreQueryRepository.SpecifyAsync(specification);
        }

        public void Update(object key, T item)
        {
            _entityFrameworkCoreCommandRepository.Update(key, item);
        }

        public Task UpdateAsync(object key, T item)
        {
            return _entityFrameworkCoreCommandRepository.UpdateAsync(key, item);
        }

        public void UpdatePartial(object key, object item)
        {
            _entityFrameworkCoreCommandRepository.UpdatePartial(key, item);
        }

        public Task UpdatePartialAsync(object key, object item)
        {
            return _entityFrameworkCoreCommandRepository.UpdatePartialAsync(key, item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _entityFrameworkCoreCommandRepository.UpdateRange(items);
        }

        public Task UpdateRangeAsync(IEnumerable<T> items)
        {
            return _entityFrameworkCoreCommandRepository.UpdateRangeAsync(items);
        }
    }
}
