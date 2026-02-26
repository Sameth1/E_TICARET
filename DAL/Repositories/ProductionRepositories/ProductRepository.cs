using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.Generics;

namespace DAL.Repositories.ProductionRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ShopContext context;

        private DbSet<Product> dbSet => context.Set<Product>(); 

        public ProductRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<Product> ReadOneAsync(Expression<Func<Product, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Active && !x.Deleted);
        }

     
    }


}
