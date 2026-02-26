using Core.Concrates.DTOs.CustomerDTOs;

namespace Core.Abstracts.IServices
{
    public interface IOrderService
    {
        /// <summary>
        /// Creates order and order items from cart, then returns the order id.
        /// </summary>
        Task<int> PlaceOrderAsync(CartDTO cart, string? userId);

        /// <summary>
        /// Gets order summaries for the given user (by UserId on Customer).
        /// </summary>
        Task<IReadOnlyList<OrderSummaryDTO>> GetOrdersByUserIdAsync(string userId);

        /// <summary>
        /// Gets order detail if the order belongs to the given user.
        /// </summary>
        Task<OrderDetailDTO?> GetOrderDetailAsync(int orderId, string userId);
    }
}
