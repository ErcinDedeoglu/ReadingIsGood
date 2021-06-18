using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Data.Entity
{
    public class Product : Entity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int AmountOfStock { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}