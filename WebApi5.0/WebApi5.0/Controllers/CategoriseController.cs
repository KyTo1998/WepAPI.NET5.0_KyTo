using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi5._0.Data;
using WebApi5._0.Model;

namespace WebApi5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriseController : ControllerBase
    {
        private readonly myDbContext _contex;

        public CategoriseController(myDbContext context)
        {
            _contex = context;
        }

        [HttpGet]
        public IActionResult getAllCategories() { 
            var lstCategories = _contex.dbCategories.ToList();
            return Ok(lstCategories);
        }

        [HttpGet("{id}")]
        public IActionResult getCategoriesById(int id)
        {
            var categories = _contex.dbCategories.SingleOrDefault(x => x.CategoriesId == id);
            if(categories != null)
            {
                return Ok(categories);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult createCategories(categoriesModel categories)
        {
            try
            {
                var cate = new dbCategory
                {
                    CategoriesName = categories.CategoriesName
                };
                _contex.Add(cate);
                _contex.SaveChanges();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoriesById(int id, categoriesModel model)
        {
            var categories = _contex.dbCategories.SingleOrDefault(x => x.CategoriesId == id);
            if (categories != null)
            {
                categories.CategoriesName = model.CategoriesName;
                _contex.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
