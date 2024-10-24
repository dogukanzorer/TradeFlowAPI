using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Payment : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<Refund> Refunds { get; set; }
    }


}
