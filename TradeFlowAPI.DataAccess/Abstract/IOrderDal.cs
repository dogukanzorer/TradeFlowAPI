using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}
