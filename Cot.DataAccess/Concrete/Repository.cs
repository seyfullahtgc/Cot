using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cot.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(CotDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return (await _dbSet.FindAsync(id))!;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.SingleOrDefaultAsync(predicate))!;
        }

        public T Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
