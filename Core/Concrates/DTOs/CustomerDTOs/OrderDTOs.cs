namespace Core.Concrates.DTOs.CustomerDTOs
{
    public class OrderSummaryDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalDue { get; set; }
        public int ItemsCount { get; set; }
    }

    public class OrderItemDetailDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalDue { get; set; }
        public List<OrderItemDetailDTO> Items { get; set; } = new();
    }
}
