using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;

namespace TradeFlowAPI.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
       private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new Result(true, "Category Added!");
        }

        public IResult Delete(Guid id)
        {
            var category = _categoryDal.Get(c => c.Id == id);
            if (category == null)
            {
                return new ErrorResult("No category found to delete.");
            }
            _categoryDal.Delete(category);
            return new SuccessResult("Successfully deleted by Category Id");
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<Category> GetById(Guid id)
        {
            var result = _categoryDal.Get(c => c.Id == id);
            if (result == null)
                return new ErrorDataResult<Category>("No category found.");

            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<List<Category>> GetByParentCategoryId(Guid parentCategoryId)
        {
            var result = _categoryDal.GetAll(c => c.ParentCategoryId == parentCategoryId);
            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<List<CategoryDetailDto>> GetAllCategoryDetails()
        {
            var categories = _categoryDal.GetAllCategoryDetails(); // DataAccess katmanındaki metodu çağırıyoruz

            if (categories != null && categories.Count > 0)
            {
                return new SuccessDataResult<List<CategoryDetailDto>>(categories, "categories listed successfully");
            }
            else
            {
                return new ErrorDataResult<List<CategoryDetailDto>>(null, "No categories found");
            }
        }

        public IResult Update(Category category)
        {
            var existingCategory = _categoryDal.Get(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return new Result (false, "No categories found");
            }

            existingCategory.Name = category.Name;
            existingCategory.ParentCategoryId = category.ParentCategoryId;

            _categoryDal.Update(existingCategory);
            return new Result(true, "Category updated successfully.");
        }
    }
    
}
