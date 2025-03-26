using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi5._0.Model;
using WebApi5._0.Services;

namespace WebApi5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryVMController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryVMController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            try
            {
                return Ok(_categoriesRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCategory(int id)
        {
            try
            {
                var data = _categoriesRepository.GetById(id);
                if (data != null) {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
              
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoriesViewModel categoriesViewModel)
        {
            try
            {
                if(id != categoriesViewModel.CategoriesId)
                {
                    return BadRequest();
                }
               _categoriesRepository.UpdateCategories(categoriesViewModel);
               return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            try
            {
                _categoriesRepository.DeleteCategories(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddNewCategories(categoriesModel categories)
        {
            try
            {
                return Ok(_categoriesRepository.AddCategories(categories));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
