using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
       private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(Guid id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public Category GetByName(string name)
        {
            return _categoryDal.Get(c => c.Name == name);
        }
    }
}
