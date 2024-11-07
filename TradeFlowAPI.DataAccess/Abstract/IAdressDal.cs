using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;

namespace TradeFlowAPI.DataAccess.Abstract
{
     public interface IAdressDal : IEntityRepository<Adress>
    {
       
    }
}
