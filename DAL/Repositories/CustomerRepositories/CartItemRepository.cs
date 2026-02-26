using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Concrates.Entities.CustomerEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.CustomerRepositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ShopContext context) : base(context)
        {
        }
    }
}
