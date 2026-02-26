using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Concrates.Entities.CustomerEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.CustomerRepositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }
    }
}
