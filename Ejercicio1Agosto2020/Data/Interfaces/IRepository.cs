using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
