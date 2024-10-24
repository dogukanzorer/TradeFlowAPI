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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            productDal = _productDal;      
        }

        public List<Product> GeByCategoryId(Guid id)
        {
           return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.Price >= min && p.Price >= max);
        }
    }
}
