using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IQueryable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task<TEntity> PatchAsync(TEntity entity);
    }
}
