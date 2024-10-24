using Core.Entities;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Adress : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }


}
