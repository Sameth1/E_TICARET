using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        Task<T?> ReadOneAsync(object entityKey);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> expression);

        Task UpdateAsync(T entity);
        Task DeleteAsync(object entityKey);
        Task DeleteAsync(T entity);

        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
