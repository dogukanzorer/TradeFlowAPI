using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Enums;


namespace TradeFlowAPI.Entities.Concrete
{
    public class User : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // GUID olarak ayarlanmış
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }

        public ICollection<Adress>? Addresses { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }


}
