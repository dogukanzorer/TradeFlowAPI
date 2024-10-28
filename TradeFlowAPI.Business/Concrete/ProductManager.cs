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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public IDataResult<List<Product>> GetByCategoryId(Guid id)
        {
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        //
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

        //
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

        public IResult Update(Product product)
        {
           var existingProduct = _productDal.Get(c => c.Id == product.Id);
            if(existingProduct == null)
            {
                return new Result(false, "No Product Found");
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.CategoryId = product.CategoryId;
            
            _productDal.Update(existingProduct);
            return new Result(true, "Product updated successfully.");
            
        }

        public IResult Delete(Guid id)
        {
           var product = _productDal.Get(c => c.Id == id);
            if(product == null)
            {
                return new ErrorResult("No Product found to delete");

            }
            _productDal.Delete(product);
            return new SuccessResult("Successfully deleted by product Id");
        }
    }
}
