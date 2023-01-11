﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _dbContext;
        private readonly DbSet<T> _entitiySet;


        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }


        public void Add(T entity)
            => _dbContext.Add(entity);


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbContext.AddAsync(entity);


        public void AddRange(IEnumerable<T> entities)
            => _dbContext.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _dbContext.AddRangeAsync(entities);


        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);


        public IQueryable<T> GetAll()
            => _entitiySet.AsQueryable();


        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
            => _entitiySet.Where(predicate).AsQueryable();

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _entitiySet;
            query = includeExpressions.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate).AsQueryable();
        }
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitiySet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression);


        public void Remove(T entity)
            => _dbContext.Remove(entity);


        public void RemoveRange(IEnumerable<T> entities)
            => _dbContext.RemoveRange(entities);


        public void Update(T entity)
            => _dbContext.Update(entity);


        public void UpdateRange(IEnumerable<T> entities)
            => _dbContext.UpdateRange(entities);
        public virtual bool IsExist(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().Any(predicate);
    }
}
