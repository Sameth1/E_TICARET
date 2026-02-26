using Core.Concrates.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Core.Abstracts.IRepositories.ICustomerRepositories
{
    public interface ICartRepository :IRepository<Cart> 
    {
    }
}
