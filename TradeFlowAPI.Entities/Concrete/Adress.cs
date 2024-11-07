using Core.Entities;
using TradeFlowAPI.Entities.Enums;


namespace TradeFlowAPI.Entities.Concrete
{
    public class Adress : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public AddressType AddressType { get; set; }  // Enum: Home, Work, etc.

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }


}
