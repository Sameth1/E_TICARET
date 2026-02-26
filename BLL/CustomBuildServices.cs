using BLL.Services;
using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concrates.Maps;
using DAL.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class CustomBuildServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(ProductMap));
            services.AddAutoMapper(typeof(CustomerMap));

            services.AddScoped<IProductionUnitOfWorks, ProductionUnitOfWorks>();
            services.AddScoped<ICustomerUnitOfWorks, CustomerUnitOfWorks>();

            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFavoritesService, FavoritesService>();



            return services;
        }


    }
}
