using BLL.Services;
using Core.Abstracts.IServices;
using Core.Concrates.DTOs.ProductionDTOs;



namespace UI_MVC.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductListItemDTO> Products { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<BrandDTO> Brands { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public HomeIndexViewModel()
        {
            Products = new List<ProductListItemDTO>();
            Categories = new List<CategoryDTO>();
            Brands = new List<BrandDTO>();
        }

       
        public IEnumerable<ProductListItemDTO> GetDataAsync()
        {
            return Products;
        }
    }
}