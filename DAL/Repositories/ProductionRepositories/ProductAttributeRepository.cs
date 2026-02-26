using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.ProductionRepositories
{
    public class ProductAttributeRepository : Repository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(ShopContext context) : base(context)
        {
        }
    }


}
