using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;

namespace TradeFlowAPI.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal :EfEntityRepositoryBase<Category,TradeFlowAPIDbContext>,ICategoryDal
    {

        public List<CategoryDetailDto> GetAllCategoryDetails()
        {
            using (TradeFlowAPIDbContext context = new TradeFlowAPIDbContext())
            {
                var result = from c in context.Categories
                             select new CategoryDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 ParentCategoryId = c.ParentCategoryId,
                                 ParentCategoryName = c.ParentCategory != null ? c.ParentCategory.Name : null // Eğer üst kategori varsa adını al
                             };

                return result.ToList();
            }
        }

    }
}
