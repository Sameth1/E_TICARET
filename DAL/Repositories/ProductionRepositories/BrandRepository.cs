using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.ProductionRepositories
{

    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {
        }
    }


}
