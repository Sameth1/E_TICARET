using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.ProductionRepositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }


}
