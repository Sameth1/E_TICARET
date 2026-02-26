using Core.Concrates.Entities.ProductionEntities;

namespace Core.Concrates.DTOs.ProductionDTOs
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal Discount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string? CoverImageURL { get; set; }
        public IEnumerable<GalleryItemDTO>? Gallery { get; set; }
        public IEnumerable<AttributeListItemDTO>? Attributes { get; set; }

        
    }
}


