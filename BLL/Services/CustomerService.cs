using AutoMapper;
using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concrates.DTOs.CustomerDTOs;
using Core.Concrates.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace BLL.Services
{
   
public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShopService _shopService;
        private const string CartSessionKey = "CartSession";

        public CartService(IHttpContextAccessor httpContextAccessor, IShopService shopService)
        {
            _httpContextAccessor = httpContextAccessor;
            _shopService = shopService;
        }

        public async Task<CartDTO> GetCartAsync()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = GetString(session, CartSessionKey);

            if (string.IsNullOrEmpty(cartJson))
                return new CartDTO();

            return JsonConvert.DeserializeObject<CartDTO>(cartJson);
        }

        public async Task AddToCartAsync(int productId, int quantity)
        {
            var cart = await GetCartAsync();
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = await _shopService.GetProduct(productId);

                cart.Items.Add(new CartItemDTO
                {
                    Id = cart.Items.Count > 0 ? cart.Items.Max(i => i.Id) + 1 : 1,
                    ProductId = product.Id,
                    ProductName = product.Title,
                    Price = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price,
                    ImageUrl = product.CoverImageURL,
                    Quantity = quantity
                });
            }

            SaveCart(cart);
        }

        public async Task UpdateQuantityAsync(int productId, int quantity)
        {
            var cart = await GetCartAsync();
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                if (quantity <= 0)
                    await RemoveFromCartAsync(productId);
                else
                {
                    existingItem.Quantity = quantity;
                    SaveCart(cart);
                }
            }
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            var cart = await GetCartAsync();
            var itemToRemove = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                SaveCart(cart);
            }
        }

        public async Task ClearCartAsync()
        {
            _httpContextAccessor.HttpContext.Session.Remove(CartSessionKey);
        }

        private void SaveCart(CartDTO cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            SetString(_httpContextAccessor.HttpContext.Session, CartSessionKey, cartJson);
        }

        private string GetString(ISession session, string key)
        {
            session.TryGetValue(key, out var data);
            return data == null ? null : Encoding.UTF8.GetString(data);
        }

        private void SetString(ISession session, string key, string value)
        {
            var data = Encoding.UTF8.GetBytes(value);
            session.Set(key, data);
        }
    }

}