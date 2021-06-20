using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Service.UOW
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(DataContext dataContext)
        {
            _entities = dataContext.Set<T>();
        }

        public T Insert(T entity)
        {
            _entities.Add(entity);

            return entity;
        }

        public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
        }

        public void PurgeAll()
        {
            _entities.RemoveRange(_entities);
        }

        public T Update(T entity)
        {
            _entities.Update(entity);

            return entity;
        }

        public void Purge(T entity)
        {
            _entities.Remove(entity);
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public async ValueTask<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _entities.FindAsync(id, cancellationToken);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken: cancellationToken);
        }


        public IQueryable<T> Query()
        {
            return _entities;
        }

        public T Random()
        {
            return _entities.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

        public async Task<T> RandomAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.OrderBy(x => Guid.NewGuid()).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}