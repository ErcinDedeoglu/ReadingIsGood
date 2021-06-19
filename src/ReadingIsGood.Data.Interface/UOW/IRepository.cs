using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Data.Interface.UOW
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);

        T InsertAsync(T entity);

        void Purge(T entity);

        void PurgeAll();

        T Update(T entity);

        T Get(int id);

        ValueTask<T> GetAsync(int id, CancellationToken cancellationToken = default);

        IEnumerable<T> GetAll();

        Task<List<T>> GetAllAsync();

        IQueryable<T> Query();

        T Random();

        Task<T> RandomAsync();
    }
}