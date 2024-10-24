using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeFlowAPI.Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
    }
}
