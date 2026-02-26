using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Abstracts.IRepositories.IProductionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IUnitOfWorks
{
    public interface ICustomerUnitOfWorks : IAsyncDisposable
    {

        ICartRepository CartRepository { get; }     

        ICartItemRepository CartItemRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderItemRepository OrderItemRepository { get; }           


        Task Commitasync();
    }
}
