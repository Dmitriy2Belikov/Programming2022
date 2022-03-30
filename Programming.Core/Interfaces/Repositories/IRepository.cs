using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Interfaces.Specifications;

namespace Programming.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(ICollection<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(ICollection<TEntity> entities);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<IQueryable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> sample);
        Task SaveChangesAsync();
    }
}
