using Core.Abstracts.Bases;
using Core.Concrates.Entities.ProductionEntities;

namespace Core.Concrates.Entities.CustomerEntities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 
        public decimal UnitPrice { get; set; } 
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
