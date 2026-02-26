using AutoMapper;
using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concrates.DTOs.ProductionDTOs;
using Core.Concrates.Entities.ProductionEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class ShopService : IShopService
    {
        private readonly IProductionUnitOfWorks productionUOW;
        private readonly IMapper mapper;

        public ShopService(IProductionUnitOfWorks productionUOW, IMapper mapper)
        {
            this.productionUOW = productionUOW;
            this.mapper = mapper;
        }

        private async Task<(IEnumerable<Product>, int)> GetProductsAsync(Expression<Func<Product, bool>>? expression, int page, int pageSize)
        {
            var query = await productionUOW.ProductRepository.ReadManyAsync(expression ?? (x => true));

            int totalCount = query.Count();
            var products = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return (products, totalCount);
        }

        public async Task<IEnumerable<BrandDTO>> GetBrands()
        {
            var data = await productionUOW.BrandRepository.ReadAllAsync();
            return mapper.Map<IEnumerable<BrandDTO>>(data);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var data = await productionUOW.CategoryRepository.ReadAllAsync();
            return mapper.Map<IEnumerable<CategoryDTO>>(data);
        }


        public async Task<ProductDetailDTO> GetProductDetail(int id)
        {
            var product = await productionUOW.ProductRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return mapper.Map<ProductDetailDTO>(product);
        }




        public async Task<ProductListItemDTO> GetProduct(int productId)
        {
            var product = await productionUOW.ProductRepository.ReadOneAsync((Expression<Func<Product, bool>>)(x => x.Id == productId && x.Active && !x.Deleted));
            return mapper.Map<ProductListItemDTO>(product);
        }

        public async Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProducts(int page, int pageSize)
        {
            var (data, totalCount) = await GetProductsAsync(x => x.Active && !x.Deleted, page, pageSize);
            return (mapper.Map<IEnumerable<ProductListItemDTO>>(data), totalCount);
        }

        public async Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProductsByBrandId(int bid, int page, int pageSize)
        {
            var (data, totalCount) = await GetProductsAsync(x => x.BrandId == bid && x.Active && !x.Deleted, page, pageSize);
            return (mapper.Map<IEnumerable<ProductListItemDTO>>(data), totalCount);
        }

        public async Task<(IEnumerable<ProductListItemDTO> Products, int TotalCount)> GetProductsByCategoryId(int cid, int page, int pageSize)
        {
            var (data, totalCount) = await GetProductsAsync(x => x.CategoryId == cid && x.Active && !x.Deleted, page, pageSize);
            return (mapper.Map<IEnumerable<ProductListItemDTO>>(data), totalCount);
        }
    }
}
