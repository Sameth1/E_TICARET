using BLL.Services;
using Core.Abstracts.IServices;
using Core.Concrates.Entities.ProductionEntities;
using UI_MVC.Factories;
using UI_MVC.Models;

namespace UI_MVC.Factories
{




    public class HomeDetailViewModelFactory : IHomeDetailViewModelFactory
    {
        private readonly IShopService shopService;

        public HomeDetailViewModelFactory(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public async Task<HomeDetailViewModel> Create(int productId)
        {

            var productDetail = await shopService.GetProductDetail(productId);
            var categories = await shopService.GetCategories();
            var brands = await shopService.GetBrands();
          

            return new HomeDetailViewModel
            {
                ProductDetail = productDetail,
                Categories = categories,
                Brands = brands
            };
        }
    }
}


