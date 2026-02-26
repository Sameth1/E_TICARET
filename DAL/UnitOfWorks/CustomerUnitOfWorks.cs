using Core.Abstracts.IRepositories.ICustomerRepositories;
using Core.Abstracts.IUnitOfWorks;
using DAL.Context;
using DAL.Repositories.CustomerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public class CustomerUnitOfWorks : ICustomerUnitOfWorks
    {
        private readonly ShopContext context;

        public CustomerUnitOfWorks(ShopContext context)
        {
            this.context = context;
        }

        private ICartRepository? cartRepository;
        public ICartRepository CartRepository => cartRepository ??= new CartRepository(context);    



        private ICartItemRepository? cartItemRepository;
        public ICartItemRepository CartItemRepository => cartItemRepository ??= new CartItemRepository(context);



        private ICustomerRepository? customerRepository;
        public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(context);



        private IOrderRepository? orderRepository;
        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository(context);



        private IOrderItemRepository? orderItemRepository;
        public IOrderItemRepository OrderItemRepository => orderItemRepository ??= new OrderItemRepository(context);        

        public async Task Commitasync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await DisposeAsync();
            }

        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
