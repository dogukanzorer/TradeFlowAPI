using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;

namespace TradeFlowAPI.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(Guid id);
        IDataResult<List<Category>> GetByParentCategoryId(Guid parentCategoryId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Guid id);
        IDataResult<List<CategoryDetailDto>> GetAllCategoryDetails();

      

    }
}
