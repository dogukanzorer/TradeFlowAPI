using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Category : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }


}
