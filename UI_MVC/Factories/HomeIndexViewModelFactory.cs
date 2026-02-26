using BLL.Services;
using Core.Abstracts.IServices;
using Core.Concrates.DTOs.ProductionDTOs;
using UI_MVC.Models;

namespace UI_MVC.Factories
{
    public class HomeIndexViewModelFactory : IHomeIndexViewModelFactory
    {
        private readonly IShopService shopService;
        private const int PageSize = 12;

        public HomeIndexViewModelFactory(IShopService shopService)
        {
            this.shopService = shopService;
        }
     

        public async Task<HomeIndexViewModel> Create(int page = 1, string? filterType = null, int? filterId = null)
        {
            IEnumerable<ProductListItemDTO> products;
            int totalCount;

            if (filterType == "category" && filterId.HasValue)
            {
                var data = await shopService.GetProductsByCategoryId(filterId.Value, page, PageSize);
                products = data.Products;
                totalCount = data.TotalCount;
            }
            else if (filterType == "brand" && filterId.HasValue)
            {
                var data = await shopService.GetProductsByBrandId(filterId.Value, page, PageSize);
                products = data.Products;
                totalCount = data.TotalCount;
            }
            else
            {
                var data = await shopService.GetProducts(page, PageSize);
                products = data.Products;
                totalCount = data.TotalCount;
            }

            var totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            return new HomeIndexViewModel
            {
                Products = products,
                Categories = await shopService.GetCategories(),
                Brands = await shopService.GetBrands(),
                CurrentPage = page,
                TotalPages = totalPages,
                Start = Math.Max(1, page - 2),
                End = Math.Min(totalPages, page + 2)
            };
        }
    }
}
