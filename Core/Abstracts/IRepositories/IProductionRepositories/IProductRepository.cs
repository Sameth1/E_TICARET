using Core.Concrates.Entities.ProductionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Core.Abstracts.IRepositories.IProductionRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> ReadOneAsync(Expression<Func<Product, bool>> predicate);
        Task<Product> GetByIdAsync(int id);
       
    }
}
