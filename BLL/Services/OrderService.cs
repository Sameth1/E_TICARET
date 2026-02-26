using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concrates.DTOs.CustomerDTOs;
using Core.Concrates.Entities.CustomerEntities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerUnitOfWorks _uow;
        private readonly ShopContext _context;

        public OrderService(ICustomerUnitOfWorks uow, ShopContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<int> PlaceOrderAsync(CartDTO cart, string? userId)
        {
            if (cart?.Items == null || cart.Items.Count == 0)
                throw new InvalidOperationException("Sepet boş.");

            var customer = await GetOrCreateCustomerAsync(userId);

            var order = new Order
            {
                CustomerId = customer.Id,
                TotalTax = 0,
                TotalDiscount = 0,
                TotalDue = cart.TotalPrice,
                CartId = 0
            };
            await _uow.OrderRepository.CreateAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart.Items)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price,
                    Price = item.Price * item.Quantity
                };
                await _uow.OrderItemRepository.CreateAsync(orderItem);
            }
            await _uow.Commitasync();
            return order.Id;
        }

        public async Task<IReadOnlyList<OrderSummaryDTO>> GetOrdersByUserIdAsync(string userId)
        {
            var customer = await _uow.CustomerRepository.ReadManyAsync(c => c.UserId == userId);
            var c = customer.FirstOrDefault();
            if (c == null) return Array.Empty<OrderSummaryDTO>();

            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == c.Id)
                .Include(o => o.Items)
                .OrderByDescending(o => o.CreateDate)
                .ToListAsync();

            return orders.Select(o => new OrderSummaryDTO
            {
                Id = o.Id,
                CreateDate = o.CreateDate,
                TotalDue = o.TotalDue,
                ItemsCount = o.Items?.Count ?? 0
            }).ToList();
        }

        public async Task<OrderDetailDTO?> GetOrderDetailAsync(int orderId, string userId)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.Items!)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order?.Customer == null || order.Customer.UserId != userId)
                return null;

            return new OrderDetailDTO
            {
                Id = order.Id,
                CreateDate = order.CreateDate,
                TotalDue = order.TotalDue,
                Items = (order.Items ?? new List<OrderItem>()).Select(i => new OrderItemDetailDTO
                {
                    ProductName = i.Product?.Title ?? "-",
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    LineTotal = i.Price
                }).ToList()
            };
        }

        private async Task<Customer> GetOrCreateCustomerAsync(string? userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var existing = await _uow.CustomerRepository.ReadManyAsync(c => c.UserId == userId);
                var c = existing.FirstOrDefault();
                if (c != null) return c;
                var newCustomer = new Customer { UserId = userId };
                await _uow.CustomerRepository.CreateAsync(newCustomer);
                await _uow.Commitasync();
                return newCustomer;
            }

            var guest = await _uow.CustomerRepository.ReadManyAsync(c => c.UserId == null && c.FirstName == "Misafir");
            var g = guest.FirstOrDefault();
            if (g != null) return g;
            var newGuest = new Customer { UserId = null, FirstName = "Misafir", LastName = "" };
            await _uow.CustomerRepository.CreateAsync(newGuest);
            await _uow.Commitasync();
            return newGuest;
        }
    }
}
