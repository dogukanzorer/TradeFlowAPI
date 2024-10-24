using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(Guid id);
        Category GetByName(string name);

    }
}
