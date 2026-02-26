using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace UI_MVC.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartSummaryViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await _cartService.GetCartAsync();
            return View(cart.TotalItems);
        }
    }
}


