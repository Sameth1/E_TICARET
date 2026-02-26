using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UI_MVC.Factories;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeIndexViewModelFactory indexFactory;
        private readonly IHomeDetailViewModelFactory detailFactory;

        public HomeController(ILogger<HomeController> logger, IHomeIndexViewModelFactory indexFactory, IHomeDetailViewModelFactory detailFactory)
        {
            _logger = logger;
            this.indexFactory = indexFactory;
            this.detailFactory = detailFactory;
        }

        public async Task<IActionResult> Index(int page = 1, string? filterType = null, int? filterId = null)
        {
            var indexViewModel = await indexFactory.Create(page, filterType, filterId);
            return View(indexViewModel);
        }

        public async Task<IActionResult> Category(int id, int page = 1)
        {
            var indexViewModel = await indexFactory.Create(page, "category", id);
            return View("Index", indexViewModel);
        }

        public async Task<IActionResult> Brand(int id, int page = 1)
        {
            var indexViewModel = await indexFactory.Create(page, "brand", id);
            return View("Index", indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await detailFactory.Create(id);
            return View("/Views/Production/Details.cshtml", viewModel);
        }
    }

    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetCartAsync();
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            await _cartService.AddToCartAsync(productId, quantity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
        {
            await _cartService.UpdateQuantityAsync(productId, quantity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _cartService.RemoveFromCartAsync(productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCartAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cart = await _cartService.GetCartAsync();
            if (cart == null || cart.Items == null || cart.Items.Count == 0)
                return RedirectToAction("Index");
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = await _cartService.GetCartAsync();
            if (cart == null || cart.Items == null || cart.Items.Count == 0)
                return RedirectToAction("Index");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                await _orderService.PlaceOrderAsync(cart, userId);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Index");
            }
            await _cartService.ClearCartAsync();
            TempData["OrderSuccess"] = true;
            return RedirectToAction("OrderComplete");
        }

        public IActionResult OrderComplete()
        {
            return View();
        }
    }
}

