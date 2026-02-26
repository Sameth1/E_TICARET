using Core.Abstracts.IServices;
using Core.Concrates.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace BLL.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShopService _shopService;
        private const string FavoritesSessionKey = "FavoritesSession";

        public FavoritesService(IHttpContextAccessor httpContextAccessor, IShopService shopService)
        {
            _httpContextAccessor = httpContextAccessor;
            _shopService = shopService;
        }

        public async Task<FavoritesDTO> GetFavoritesAsync()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var json = GetString(session, FavoritesSessionKey);
            if (string.IsNullOrEmpty(json))
                return new FavoritesDTO();
            var dto = JsonConvert.DeserializeObject<FavoritesDTO>(json);
            return dto ?? new FavoritesDTO();
        }

        public async Task AddToFavoritesAsync(int productId)
        {
            var favorites = await GetFavoritesAsync();
            if (favorites.Items.Any(i => i.ProductId == productId))
                return;
            var product = await _shopService.GetProduct(productId);
            favorites.Items.Add(new FavoriteItemDTO
            {
                ProductId = product.Id,
                ProductName = product.Title ?? "",
                ImageUrl = product.CoverImageURL ?? "",
                Price = product.Price,
                DiscountedPrice = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price
            });
            SaveFavorites(favorites);
        }

        public async Task RemoveFromFavoritesAsync(int productId)
        {
            var favorites = await GetFavoritesAsync();
            var item = favorites.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                favorites.Items.Remove(item);
                SaveFavorites(favorites);
            }
        }

        public async Task<bool> IsInFavoritesAsync(int productId)
        {
            var favorites = await GetFavoritesAsync();
            return favorites.Items.Any(i => i.ProductId == productId);
        }

        private void SaveFavorites(FavoritesDTO favorites)
        {
            var json = JsonConvert.SerializeObject(favorites);
            SetString(_httpContextAccessor.HttpContext.Session, FavoritesSessionKey, json);
        }

        private static string? GetString(ISession session, string key)
        {
            session.TryGetValue(key, out var data);
            return data == null ? null : Encoding.UTF8.GetString(data);
        }

        private static void SetString(ISession session, string key, string value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(value));
        }
    }
}
