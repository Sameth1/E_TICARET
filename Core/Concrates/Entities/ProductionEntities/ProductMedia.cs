using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.ProductionEntities
{
    public class ProductMedia : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string? Source { get; set; }
        public string? MediaType { get; set; }
    }
}
