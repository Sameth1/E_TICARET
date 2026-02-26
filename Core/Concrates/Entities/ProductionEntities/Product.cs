using Core.Abstracts.Bases;
using Core.Concrates.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.ProductionEntities
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TaxRate { get; set; }
        public string? CoverImageURL { get; set; }

        public int CategoryId { get; set; }
       
        public virtual Category? Category { get; set; }

        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new HashSet<ProductAttribute>();
        public virtual ICollection<ProductMedia> Gallery { get; set; } = new HashSet<ProductMedia>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
