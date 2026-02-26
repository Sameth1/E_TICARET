using Core.Abstracts.Bases;
using Core.Concrates.Entities.ProductionEntities;

namespace Core.Concrates.Entities.CustomerEntities
{
    public class CartItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; } = 0;
        public int CartId { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
