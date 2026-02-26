namespace Core.Concrates.DTOs.ProductionDTOs
{
    public class ProductListItemDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? CoverImageURL { get; set; }
    }
}


