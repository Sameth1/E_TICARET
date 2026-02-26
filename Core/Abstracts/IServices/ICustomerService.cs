using Core.Concrates.DTOs.CustomerDTOs;

namespace Core.Abstracts.IServices
{
    public interface ICartService
    {
        Task<CartDTO> GetCartAsync();
        Task AddToCartAsync(int productId, int quantity);
        Task UpdateQuantityAsync(int productId, int quantity);
        Task RemoveFromCartAsync(int productId);
        Task ClearCartAsync();
    }
}
