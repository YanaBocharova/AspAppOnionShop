using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product: BaseEntity<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
        public void Copy(Product from)
        {
            Name = from.Name;
            Price = from.Price;
            Category.Id = from.Category.Id;
        }
    }
}
