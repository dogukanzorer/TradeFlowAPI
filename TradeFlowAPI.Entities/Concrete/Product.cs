using Core.Entities;

namespace TradeFlowAPI.Entities.Concrete
{
    public class Product : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }


}
