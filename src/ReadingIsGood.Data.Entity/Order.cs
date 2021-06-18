using System.Collections.Generic;

namespace ReadingIsGood.Data.Entity
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Enum.OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}