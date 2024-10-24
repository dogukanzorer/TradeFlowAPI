using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : EfEntityRepositoryBase<Product, TradeFlowAPIDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (TradeFlowAPIDbContext context = new TradeFlowAPIDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto { ProductId = p.Id, ProductName = p.Name, CategoryName = c.Name, Stock = p.Stock };
                return result.ToList();
            }
        }
    }
}
