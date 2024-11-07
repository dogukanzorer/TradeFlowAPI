using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Enums;

namespace TradeFlowAPI.Entities.DTOs
{
    public class AdressDetailDto
    {
        // Adresin sokağını belirten alan
        public string Street { get; set; }

        // Adresin şehrini belirten alan
        public string City { get; set; }

        // Adresin eyaletini belirten alan
        public string State { get; set; }

        // Adresin posta kodunu belirten alan
        public string ZipCode { get; set; }

        // Adresin hangi kullanıcıya ait olduğunu belirten alan
        public Guid UserId { get; set; }

        // Adresin türünü belirten alan (Home, Work, Shipping vb.)
        public AddressType AddressType { get; set; }
    }
}
