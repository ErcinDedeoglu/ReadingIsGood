using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Data.Entity
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Enum.OrderStatus OrderStatus { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}