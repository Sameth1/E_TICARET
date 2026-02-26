using Core.Abstracts.Bases;

namespace Core.Concrates.Entities.CustomerEntities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderItem>? Items { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalDue { get; set; }
        public int CartId { get; set; } 
    }
}
