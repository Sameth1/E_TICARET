using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.ProductionEntities
{
    public class ProductAttribute : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
