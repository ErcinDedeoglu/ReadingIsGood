namespace ReadingIsGood.Data.Entity
{
    public class OrderDetail : Entity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Enum.OrderDetailStatus OrderDetailStatus { get; set; }
    }
}