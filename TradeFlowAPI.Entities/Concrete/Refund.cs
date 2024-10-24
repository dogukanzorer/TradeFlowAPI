using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Refund : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
    }


}
