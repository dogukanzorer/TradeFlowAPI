using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.Business.Concrete;
using TradeFlowAPI.DataAccess.Concrete.EntityFramework;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            
            var result = _productService.GetAll();
            return result.Data;
        }

    }
}
