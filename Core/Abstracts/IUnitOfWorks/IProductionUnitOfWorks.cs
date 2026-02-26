using Core.Abstracts.IRepositories.IProductionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IUnitOfWorks
{
    public interface IProductionUnitOfWorks : IAsyncDisposable
    {
       

        IBrandRepository BrandRepository { get; }

        ICategoryRepository CategoryRepository { get; } 

        IProductRepository ProductRepository { get; }

        IProductAttributeRepository ProductAttributeRepository { get; }

        IProductMediaRepository ProductMediaRepository { get; }     


        Task Commitasync();
    }
}
