using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _categoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("categoryDetailsDto")]
        public IActionResult GetAllCategoryDetails()
        {
            var result = _categoryService.GetAllCategoryDetails();
            if (result.Success)
            {
                return Ok(result); // Başarılı sonuç döner
            }
            return BadRequest(result); // Hata durumunda bad request döner
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(Guid id)
        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByParentCategoryId")]
        public IActionResult GetByParentCategoryId(Guid ParentCategoryId)
        {
            var result = _categoryService.GetByParentCategoryId(ParentCategoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
