using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Order : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public Guid ShippingAddressId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public Shipping Shipping { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }


}
