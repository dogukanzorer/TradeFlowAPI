using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Discount : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }


}
