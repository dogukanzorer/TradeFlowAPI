using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GeByCategoryId(Guid id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
