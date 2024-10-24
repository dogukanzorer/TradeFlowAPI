using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Coupon : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }


}
