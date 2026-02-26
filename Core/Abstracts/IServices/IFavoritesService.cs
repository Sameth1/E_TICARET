using Core.Concrates.DTOs.CustomerDTOs;

namespace Core.Abstracts.IServices
{
    public interface IFavoritesService
    {
        Task<FavoritesDTO> GetFavoritesAsync();
        Task AddToFavoritesAsync(int productId);
        Task RemoveFromFavoritesAsync(int productId);
        Task<bool> IsInFavoritesAsync(int productId);
    }
}
