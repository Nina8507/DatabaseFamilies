using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseFamilies.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(int predicate);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}