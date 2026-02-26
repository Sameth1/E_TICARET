using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.ProductionRepositories
{
    public class ProductMediaRepository : Repository<ProductMedia>, IProductMediaRepository
    {
        public ProductMediaRepository(ShopContext context) : base(context)
        {
        }
    }


}
