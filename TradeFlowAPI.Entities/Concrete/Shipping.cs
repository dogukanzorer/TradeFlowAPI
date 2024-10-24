using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Shipping : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShippingMethod { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }


}
