using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Concrates.Entities.CustomerEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.CustomerRepositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ShopContext context) : base(context)
        {
        }
    }
}
