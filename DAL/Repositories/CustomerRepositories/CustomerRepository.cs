using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Concrates.Entities.CustomerEntities;
using DAL.Context;
using Utilities.Generics;

namespace DAL.Repositories.CustomerRepositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopContext context) : base(context)
        {
        }
    }
}
