using Core.Concrates.DTOs.CustomerDTOs;
using Core.Concrates.DTOs.ProductionDTOs;

namespace Core.Abstracts.IServices
{
    public interface IShopService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<BrandDTO>> GetBrands();
        Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProducts(int page, int pageSize);
        Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProductsByCategoryId(int id, int page, int pageSize);
        Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProductsByBrandId(int id, int page, int pageSize);
        Task<ProductDetailDTO> GetProductDetail(int id);
        Task<ProductListItemDTO> GetProduct(int productId);
    }
}