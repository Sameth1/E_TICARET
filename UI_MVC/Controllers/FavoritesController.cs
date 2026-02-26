using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace UI_MVC.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoritesService _favoritesService;
        private readonly ICartService _cartService;

        public FavoritesController(IFavoritesService favoritesService, ICartService cartService)
        {
            _favoritesService = favoritesService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var favorites = await _favoritesService.GetFavoritesAsync();
            return View(favorites);
        }

        public async Task<IActionResult> Add(int productId, string? returnUrl = null)
        {
            await _favoritesService.AddToFavoritesAsync(productId);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int productId, string? returnUrl = null)
        {
            await _favoritesService.RemoveFromFavoritesAsync(productId);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddToCart(int productId, string? returnUrl = null)
        {
            await _cartService.AddToCartAsync(productId, 1);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(nameof(Index));
        }
    }
}
