namespace Core.Concrates.DTOs.CustomerDTOs
{
    public class FavoriteItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
    }

    public class FavoritesDTO
    {
        public List<FavoriteItemDTO> Items { get; set; } = new List<FavoriteItemDTO>();
    }
}
