using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class ProductImage : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageUrl { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }


}
