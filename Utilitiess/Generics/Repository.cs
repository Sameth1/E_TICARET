using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        protected DbSet<T> _set;

        protected Repository(DbContext context)
        {
            this.context = context;
            _set = this.context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {

            await _set.AddAsync(entity);
        }

        public virtual async Task<T?> ReadOneAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> expression)
        {
            return await _set.Where(expression).ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {

            await Task.Run(() => _set.Update(entity));
        }

        public virtual async Task DeleteAsync(object entityKey)
        {
            var entity = await ReadOneAsync(entityKey);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _set.Remove(entity));
        }






        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            if (expression == null)
            {
                return await _set.CountAsync();
            }
            else
            {
                return await _set.CountAsync(expression);
            }
        }


        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _set.AnyAsync(expression);
        }
    }
}
