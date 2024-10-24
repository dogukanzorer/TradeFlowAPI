using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.Business.Constants;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.DTOs;

namespace TradeFlowAPI.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
           _productDal = productDal;      
        }

       
        //
        public IDataResult<List<Product>> GeByCategoryId(Guid id)
        {
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAll()

        {
           /* if(DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Product>>("Hata!");
            }
           */
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"Product added!");
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price >= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        //
        public IDataResult<Product> GetById(Guid id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }

        public IResult Add(Product product)
        {
            if(product.Name.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new Result(true,Messages.ProductAdded);
        }
    }
}
