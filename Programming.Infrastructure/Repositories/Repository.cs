using System;
using Microsoft.EntityFrameworkCore;
using Programming.Core;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Programming.Core.Interfaces.Repositories;
using Programming.Core.Interfaces.Specifications;

namespace Programming.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void UpdateRange(ICollection<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            var entity = await _entities.FindAsync(keyValues);

            return entity;
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.FromResult(_entities);
        }

        public async Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> sample)
        {
            var entities = _entities.Where(sample);

            return await Task.FromResult(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
