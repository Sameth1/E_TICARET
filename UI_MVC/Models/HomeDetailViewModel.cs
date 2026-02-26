
using Core.Abstracts.IServices;
using Core.Concrates.DTOs.ProductionDTOs;

namespace UI_MVC.Models
{
 
    public class HomeDetailViewModel
    {
        public ProductDetailDTO ProductDetail { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<BrandDTO> Brands { get; set; }

        public HomeDetailViewModel()
        {
            ProductDetail = new ProductDetailDTO();
            Categories = new List<CategoryDTO>();
            Brands = new List<BrandDTO>();
        }
    }
}
