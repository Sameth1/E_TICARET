using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Concrates.Entities.CustomerEntities;
using Core.Concrates.Entities.ProductionEntities;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace DAL.Repositories.CustomerRepositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ShopContext context) : base(context)
        {
        }
    }
}
