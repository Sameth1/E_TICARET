using Core.Abstracts.IRepositories.IProductionRepositories;
using Core.Abstracts.IUnitOfWorks;
using DAL.Context;
using DAL.Repositories.ProductionRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public class ProductionUnitOfWorks : IProductionUnitOfWorks
    {
        private readonly ShopContext context;

        public ProductionUnitOfWorks(ShopContext context)
        {
            this.context = context;
        }

        private IBrandRepository? brandRepository;
        public IBrandRepository BrandRepository => brandRepository ??= new BrandRepository(context);



        
        private ICategoryRepository? categoryRepository;     
        public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(context);



        private IProductRepository? productRepository;
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(context);




        private IProductAttributeRepository? productAttributeRepository;
        public IProductAttributeRepository ProductAttributeRepository => productAttributeRepository ??= new ProductAttributeRepository(context);

       

        public IProductMediaRepository? productMediaRepository;
        public IProductMediaRepository ProductMediaRepository => productMediaRepository ??= new ProductMediaRepository(context);

        public async Task Commitasync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await DisposeAsync();
            }

        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }


    }
