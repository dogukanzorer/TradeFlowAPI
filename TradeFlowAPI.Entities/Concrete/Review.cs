using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Review : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; }
        public int Rating { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }


}
